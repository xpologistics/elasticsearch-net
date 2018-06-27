using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Elastic.Managed.Ephemeral;
using Elastic.Xunit;
using Elasticsearch.Net;
using Nest;

namespace Tests.Framework.ManagedElasticsearch
{
	internal static class EphemeralClusterExtensions
	{
		public static bool RunningFiddler => Process.GetProcessesByName("fiddler").Any();

		public static IElasticClient GetOrAddClient<TConfig>(
			this IEphemeralCluster<TConfig> cluster,
			Func<ConnectionSettings, ConnectionSettings> createSettings = null,
			Func<ICollection<Uri>, IConnectionPool> createPool = null)
			where TConfig : EphemeralClusterConfiguration
		{
			createSettings = createSettings ?? (s => s);
			return cluster.GetOrAddClient(c => CreateClient((IEphemeralCluster<TConfig>)c, createSettings, createPool));
		}

		public static ElasticClient CreateClient<TConfig>(
			this IEphemeralCluster<TConfig> cluster,
			Func<ConnectionSettings, ConnectionSettings> createSettings = null,
			Func<ICollection<Uri>, IConnectionPool> createPool = null)
			where TConfig : EphemeralClusterConfiguration
		{
			var host = (RunningFiddler) ? "ipv4.fiddler" : "localhost";
			createPool = createPool ?? (uris => new StaticConnectionPool(uris));
			var connectionPool = createPool(cluster.NodesUris(host));
			var connection = TestClient.Configuration.RunIntegrationTests ? TestClient.CreateLiveConnection() : new InMemoryConnection();
			var settings = TestClient.CreateSettings(createSettings, connection, connectionPool);

			var current = (IConnectionConfigurationValues) settings;
			var notAlreadyAuthenticated = current.BasicAuthenticationCredentials == null && current.ClientCertificates == null;
			var noCertValidation = current.ServerCertificateValidationCallback == null;

			if (cluster.ClusterConfiguration.EnableSecurity && notAlreadyAuthenticated)
				settings = settings.BasicAuthentication(ClusterAuthentication.Admin.Username, ClusterAuthentication.Admin.Password);
			if (cluster.ClusterConfiguration.EnableSsl && noCertValidation)
			{
				settings = settings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);
			}
			var client = new ElasticClient(settings);
			return client;
		}
	}
}
