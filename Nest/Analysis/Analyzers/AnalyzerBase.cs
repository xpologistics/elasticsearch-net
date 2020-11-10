﻿using Newtonsoft.Json;

namespace Nest6
{
	[ContractJsonConverter(typeof(AnalyzerJsonConverter))]
	public interface IAnalyzer
	{
		[JsonProperty("type")]
		string Type { get; }

		[JsonProperty("version")]
		string Version { get; set; }
	}

	public abstract class AnalyzerBase : IAnalyzer
	{
		internal AnalyzerBase() { }

		protected AnalyzerBase(string type) => Type = type;

		public virtual string Type { get; protected set; }

		public string Version { get; set; }
	}

	public abstract class AnalyzerDescriptorBase<TAnalyzer, TAnalyzerInterface>
		: DescriptorBase<TAnalyzer, TAnalyzerInterface>, IAnalyzer
		where TAnalyzer : AnalyzerDescriptorBase<TAnalyzer, TAnalyzerInterface>, TAnalyzerInterface
		where TAnalyzerInterface : class, IAnalyzer
	{
		protected abstract string Type { get; }
		string IAnalyzer.Type => Type;
		string IAnalyzer.Version { get; set; }

		public TAnalyzer Version(string version) => Assign(version, (a, v) => a.Version = v);
	}
}
