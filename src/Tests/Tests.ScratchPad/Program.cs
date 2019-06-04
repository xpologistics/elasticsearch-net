using System;
using BenchmarkDotNet.Running;
using Elasticsearch.Net;
using Tests.ScratchPad.Runners.ApiCalls;

namespace Tests.ScratchPad
{
	public class Program
	{
		private static void Main(string[] args)
		{
			var client = new ElasticLowLevelClient(new ConnectionConfiguration().EnableDebugMode());

			var response =  client.Search<StringResponse>(PostData.Serializable(new {}));


			Console.WriteLine(response.DebugInformation);
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
