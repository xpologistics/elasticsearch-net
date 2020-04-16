using System;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.XPack.Usage
{
	[SkipVersion("<7.7.0", "Index usage introduced in 7.7.0")]
	public class IndexXPackUsageApiTests
		: ApiIntegrationTestBase<XPackCluster, XPackUsageResponse, IXPackUsageRequest, XPackUsageDescriptor, XPackUsageRequest>
	{
		public IndexXPackUsageApiTests(XPackCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override void IntegrationSetup(IElasticClient client, CallUniqueValues values) =>
			client.Indices.Create("text-index1", i => i
				.Settings(s => s
					.Analysis(a => a
						.CharFilters(c => c
							.Mapping("c", f => f
								.Mappings("a => b")
							)
						)
					)
				)
			);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;

		protected override Func<XPackUsageDescriptor, IXPackUsageRequest> Fluent => d => d;

		protected override HttpMethod HttpMethod => HttpMethod.POST;

		protected override XPackUsageRequest Initializer => new XPackUsageRequest();

		protected override string UrlPath => $"/_xpack/usage";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.XPack.Usage(f),
			(client, f) => client.XPack.UsageAsync(f),
			(client, r) => client.XPack.Usage(r),
			(client, r) => client.XPack.UsageAsync(r)
		);

		protected override void ExpectResponse(XPackUsageResponse response)
		{
		}
	}
}
