using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest6;
using Tests.Domain;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.XPack.Rollup.RollupSearch
{
	public class RollupSearchUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls()
		{
			const string index = "default-index";
			await POST($"/{index}/_rollup_search")
				.Fluent(c => c.RollupSearch<Log>(index, s => s))
				.Request(c => c.RollupSearch<Log>(new RollupSearchRequest(index)))
				.FluentAsync(c => c.RollupSearchAsync<Log>(index, s => s))
				.RequestAsync(c => c.RollupSearchAsync<Log>(new RollupSearchRequest(index)));

			await POST($"/_all/_rollup_search")
				.Fluent(c => c.RollupSearch<Log>(Nest6.Indices.All, s => s))
				.Request(c => c.RollupSearch<Log>(new RollupSearchRequest(Nest6.Indices.All)))
				.FluentAsync(c => c.RollupSearchAsync<Log>(Nest6.Indices.All, s => s))
				.RequestAsync(c => c.RollupSearchAsync<Log>(new RollupSearchRequest(Nest6.Indices.All)));
		}
	}
}
