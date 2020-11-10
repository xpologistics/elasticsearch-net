﻿using Newtonsoft.Json;

namespace Nest6
{
	[ContractJsonConverter(typeof(TokenizerJsonConverter))]
	public interface ITokenizer
	{
		[JsonProperty("type")]
		string Type { get; }

		[JsonProperty("version")]
		string Version { get; set; }
	}

	public abstract class TokenizerBase : ITokenizer
	{
		public string Type { get; protected set; }
		public string Version { get; set; }
	}

	public abstract class TokenizerDescriptorBase<TTokenizer, TTokenizerInterface>
		: DescriptorBase<TTokenizer, TTokenizerInterface>, ITokenizer
		where TTokenizer : TokenizerDescriptorBase<TTokenizer, TTokenizerInterface>, TTokenizerInterface
		where TTokenizerInterface : class, ITokenizer
	{
		protected abstract string Type { get; }
		string ITokenizer.Type => Type;
		string ITokenizer.Version { get; set; }

		public TTokenizer Version(string version) => Assign(version, (a, v) => a.Version = v);
	}
}
