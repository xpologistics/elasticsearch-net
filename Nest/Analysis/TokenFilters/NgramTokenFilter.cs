﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A token filter of type nGram.
	/// </summary>
	public interface INGramTokenFilter : ITokenFilter
	{
		/// <summary>
		/// Defaults to 2
		/// </summary>
		[JsonProperty("max_gram")]
		int? MaxGram { get; set; }

		/// <summary>
		/// Defaults to 1.
		/// </summary>
		[JsonProperty("min_gram")]
		int? MinGram { get; set; }
	}

	/// <inheritdoc />
	public class NGramTokenFilter : TokenFilterBase, INGramTokenFilter
	{
		public NGramTokenFilter() : base("ngram") { }

		/// <inheritdoc />
		public int? MaxGram { get; set; }

		/// <inheritdoc />
		public int? MinGram { get; set; }
	}

	/// <inheritdoc />
	public class NGramTokenFilterDescriptor
		: TokenFilterDescriptorBase<NGramTokenFilterDescriptor, INGramTokenFilter>, INGramTokenFilter
	{
		protected override string Type => "ngram";
		int? INGramTokenFilter.MaxGram { get; set; }

		int? INGramTokenFilter.MinGram { get; set; }

		/// <inheritdoc />
		public NGramTokenFilterDescriptor MinGram(int? minGram) => Assign(minGram, (a, v) => a.MinGram = v);

		/// <inheritdoc />
		public NGramTokenFilterDescriptor MaxGram(int? maxGram) => Assign(maxGram, (a, v) => a.MaxGram = v);
	}
}
