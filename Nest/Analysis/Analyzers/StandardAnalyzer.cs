﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// An analyzer of type standard that is built of using Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token
	/// Filter.
	/// </summary>
	public interface IStandardAnalyzer : IAnalyzer
	{
		/// <summary>
		/// The maximum token length. If a token is seen that exceeds this length then it is discarded. Defaults to 255.
		/// </summary>
		[JsonProperty("max_token_length")]
		int? MaxTokenLength { get; set; }

		/// <summary>
		/// A list of stopword to initialize the stop filter with. Defaults to the english stop words.
		/// </summary>
		[JsonProperty("stopwords")]
		[JsonConverter(typeof(StopWordsJsonConverter))]
		StopWords StopWords { get; set; }
	}

	/// <inheritdoc />
	public class StandardAnalyzer : AnalyzerBase, IStandardAnalyzer
	{
		public StandardAnalyzer() : base("standard") { }

		/// <inheritdoc />
		public int? MaxTokenLength { get; set; }

		/// <inheritdoc />
		public StopWords StopWords { get; set; }
	}

	/// <inheritdoc />
	public class StandardAnalyzerDescriptor : AnalyzerDescriptorBase<StandardAnalyzerDescriptor, IStandardAnalyzer>, IStandardAnalyzer
	{
		protected override string Type => "standard";
		int? IStandardAnalyzer.MaxTokenLength { get; set; }

		StopWords IStandardAnalyzer.StopWords { get; set; }

		public StandardAnalyzerDescriptor StopWords(params string[] stopWords) =>
			Assign(stopWords, (a, v) => a.StopWords = v);

		public StandardAnalyzerDescriptor StopWords(IEnumerable<string> stopWords) =>
			Assign(stopWords.ToListOrNullIfEmpty(), (a, v) => a.StopWords = v);

		public StandardAnalyzerDescriptor StopWords(StopWords stopWords) => Assign(stopWords, (a, v) => a.StopWords = v);

		public StandardAnalyzerDescriptor MaxTokenLength(int? maxTokenLength) =>
			Assign(maxTokenLength, (a, v) => a.MaxTokenLength = v);
	}
}
