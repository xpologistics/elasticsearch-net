using System;
using System.Text;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;

namespace Tests.Reproduce
{
	public class GithubIssue4633
	{
		[U]
		public void IndexManyAppliesIgnoreProperties()
		{
			var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
			var settings = new  ConnectionSettings(pool, new InMemoryConnection())
				.DisableDirectStreaming()
				.DefaultMappingFor<Foo>(m => m
					.Ignore(p => p.Baz)
					.IndexName("foos")
				);

			var client = new ElasticClient(settings);
			var docs = new[] { new Foo { Bar = "bar", Baz = "baz" }, };
			var bulkResponse = client.IndexMany(docs);

			var actual = Encoding.UTF8.GetString(bulkResponse.ApiCall.RequestBodyInBytes);
			actual.Should().Be("{\"index\":{\"_id\":null,\"_index\":\"foos\"}}\n{\"bar\":\"bar\"}\n");
		}

		public class Foo
		{
			public string Bar { get; set; }
			public string Baz { get; set; }
 		}
	}
}
