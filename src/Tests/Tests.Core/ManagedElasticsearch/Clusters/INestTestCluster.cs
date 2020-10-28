using Nest6;

namespace Tests.Core.ManagedElasticsearch.Clusters
{
	public interface INestTestCluster
	{
		IElasticClient Client { get; }
	}
}
