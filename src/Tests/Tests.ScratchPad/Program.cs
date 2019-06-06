using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Elasticsearch.Net;
using Nest;
using Tests.Core.Client.Settings;
using Tests.Core.ManagedElasticsearch.NodeSeeders;
using Tests.Domain.Extensions;
using Tests.ScratchPad.Runners.ApiCalls;

namespace Tests.ScratchPad
{
	public class Program
	{
		private static async Task Main(string[] args)
		{
			var client = new ElasticClient(new TestConnectionSettings().ApplyDomainSettings().EnableDebugMode());
			var x = new DefaultSeeder(client);
			
			x.SeedNode();
			Console.WriteLine("Done");
		}

		private static void Bench<TBenchmark>() where TBenchmark : RunBase => BenchmarkRunner.Run<TBenchmark>();

		private static void Run<TRun>() where TRun : RunBase, new()
		{
			var runner = new TRun { IsNotBenchmark = true };
			runner.GlobalSetup();
			runner.Run();
		}

		private static void RunCreateOnce<TRun>() where TRun : RunBase, new()
		{
			var runner = new TRun { IsNotBenchmark = true };
			runner.GlobalSetup();
			runner.RunCreateOnce();
		}
	}
}
