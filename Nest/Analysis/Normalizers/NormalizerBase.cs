﻿using Newtonsoft.Json;

namespace Nest6
{
	[ContractJsonConverter(typeof(NormalizerJsonConverter))]
	public interface INormalizer
	{
		[JsonProperty("type")]
		string Type { get; }

		[JsonProperty("version")]
		string Version { get; set; }
	}

	public abstract class NormalizerBase : INormalizer
	{
		internal NormalizerBase() { }

		protected NormalizerBase(string type) => Type = type;

		public virtual string Type { get; protected set; }

		public string Version { get; set; }
	}

	public abstract class NormalizerDescriptorBase<TNormalizer, TNormalizerInterface>
		: DescriptorBase<TNormalizer, TNormalizerInterface>, INormalizer
		where TNormalizer : NormalizerDescriptorBase<TNormalizer, TNormalizerInterface>, TNormalizerInterface
		where TNormalizerInterface : class, INormalizer
	{
		protected abstract string Type { get; }
		string INormalizer.Type => Type;
		string INormalizer.Version { get; set; }

		public TNormalizer Version(string version) => Assign(version, (a, v) => a.Version = v);
	}
}
