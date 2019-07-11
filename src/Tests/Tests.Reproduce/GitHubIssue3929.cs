using System;
using System.Text;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;

namespace Tests.Reproduce
{
	public class GitHubIssue3929
	{
		public class Status
		{
			public string Name { get; set; }
			public string Description { get; set; }
			public string Severity { get; set; }
		}

		public class OrderStatus : Status
		{
		}

		public class EnquiryStatus : Status
		{
		}

		[U]
		public void InheritDefaultMappingFor()
		{
			var defaultIndex = "posts";
			var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));

			var settings = new ConnectionSettings(pool, new InMemoryConnection())
				.DefaultIndex(defaultIndex)
				.DefaultMappingFor<Status>(s => s
					.Ignore(i => i.Description)
					.Ignore(i => i.Severity))
				.DisableDirectStreaming();

			var client = new ElasticClient(settings);

			var indexResponse = client.IndexDocument(new OrderStatus { Name = "name", Description = "description", Severity = "severity" });

			Encoding.UTF8.GetString(indexResponse.ApiCall.RequestBodyInBytes).Should().NotContain("description").And.NotContain("severity");
		}
	}
}
