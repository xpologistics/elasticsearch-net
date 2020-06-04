// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text;
using BenchmarkDotNet.Attributes;
using Nest;
using Tests.Benchmarking.Framework;
using Tests.Core.Client;

namespace Tests.Benchmarking
{
	[BenchmarkConfig(5)]
	public class GitHubIssue4734Benchmark
	{
		[GlobalSetup]
		public void Setup() => Client = TestClient.FixedInMemoryClient(Encoding.UTF8.GetBytes(@"{
			""took"" : 0,
			""timed_out"" : false,
			""_shards"" : {
				""total"" : 1,
				""successful"" : 1,
				""skipped"" : 0,
				""failed"" : 0
			},
			""hits"" : {
				""total"" : {
					""value"" : 4,
					""relation"" : ""eq""
				},
				""max_score"" : 1.0,
				""hits"" : [
				{
					""_index"" : ""test2"",
					""_type"" : ""_doc"",
					""_id"" : ""ca29c3IBf1szuS2CHI_V"",
					""_score"" : 1.0,
					""_source"" : {
						""name"" : ""苹果X/iphone x"",
						""des"" : ""当天发货/24期分期Apple/苹果iPhone 11官方旗舰店国行苹果11全网通4G手机x官方xr iPhone se新品11pro xsmax""
					}
				},
				{
					""_index"" : ""test2"",
					""_type"" : ""_doc"",
					""_id"" : ""c629c3IBf1szuS2CJ4_0"",
					""_score"" : 1.0,
					""_source"" : {
						""name"" : ""苹果X手机壳"",
						""des"" : ""苹果X手机壳硅胶iPhonexsmax浮雕iPhonex全包防摔xr磨砂男女款软""
					}
				},
				{
					""_index"" : ""test2"",
					""_type"" : ""_doc"",
					""_id"" : ""da29c3IBf1szuS2CMI-D"",
					""_score"" : 1.0,
					""_source"" : {
						""name"" : ""苹果6s手机壳"",
						""des"" : ""苹果6s手机壳硅胶iPhone 6s浮雕iPhone 6x全包防摔xr磨砂男女款软""
					}
				},
				{
					""_index"" : ""test2"",
					""_type"" : ""_doc"",
					""_id"" : ""d629c3IBf1szuS2CO48v"",
					""_score"" : 1.0,
					""_source"" : {
						""name"" : ""苹果笔记本"",
						""des"" : ""苹果笔记本2020版macbook air mackoob pro""
					}
				}
				]
			}
		}"));

		public IElasticClient Client { get; set; }

		[Benchmark(Description = "Deserialize", OperationsPerInvoke = 1000)]
		public void Deserialize() => Client.Search<MyDocument>(s => s.Index("index"));


		public class MyDocument
		{
			public string Name { get; set; }
			public string Des { get; set; }
		}
	}
}
