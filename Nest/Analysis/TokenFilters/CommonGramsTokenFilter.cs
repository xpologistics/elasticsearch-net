﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	///  Token filter that generates bigrams for frequently occuring terms. Single terms are still indexed.
	/// <para>Note, common_words or common_words_path field is required.</para>
	/// </summary>
	public interface ICommonGramsTokenFilter : ITokenFilter
	{
		/// <summary>
		/// A list of common words to use.
		/// </summary>
		[JsonProperty("common_words")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<string>))]
		IEnumerable<string> CommonWords { get; set; }

		/// <summary>
		/// A path (either relative to config location, or absolute) to a list of common words.
		/// </summary>
		[JsonProperty("common_words_path")]
		string CommonWordsPath { get; set; }

		/// <summary>
		/// If true, common words matching will be case insensitive.
		/// </summary>
		[JsonProperty("ignore_case")]
		bool? IgnoreCase { get; set; }

		/// <summary>
		/// Generates bigrams then removes common words and single terms followed by a common word.
		/// </summary>
		[JsonProperty("query_mode")]
		bool? QueryMode { get; set; }
	}

	/// <inheritdoc />
	public class CommonGramsTokenFilter : TokenFilterBase, ICommonGramsTokenFilter
	{
		public CommonGramsTokenFilter() : base("common_grams") { }

		/// <inheritdoc />
		public IEnumerable<string> CommonWords { get; set; }

		/// <inheritdoc />
		public string CommonWordsPath { get; set; }

		/// <inheritdoc />
		public bool? IgnoreCase { get; set; }

		/// <inheritdoc />
		public bool? QueryMode { get; set; }
	}

	/// <inheritdoc />
	public class CommonGramsTokenFilterDescriptor
		: TokenFilterDescriptorBase<CommonGramsTokenFilterDescriptor, ICommonGramsTokenFilter>, ICommonGramsTokenFilter
	{
		protected override string Type => "common_grams";

		IEnumerable<string> ICommonGramsTokenFilter.CommonWords { get; set; }
		string ICommonGramsTokenFilter.CommonWordsPath { get; set; }
		bool? ICommonGramsTokenFilter.IgnoreCase { get; set; }
		bool? ICommonGramsTokenFilter.QueryMode { get; set; }

		/// <inheritdoc />
		public CommonGramsTokenFilterDescriptor QueryMode(bool? queryMode = true) => Assign(queryMode, (a, v) => a.QueryMode = v);

		/// <inheritdoc />
		public CommonGramsTokenFilterDescriptor IgnoreCase(bool? ignoreCase = true) => Assign(ignoreCase, (a, v) => a.IgnoreCase = v);

		/// <inheritdoc />
		public CommonGramsTokenFilterDescriptor CommonWordsPath(string path) => Assign(path, (a, v) => a.CommonWordsPath = v);

		/// <inheritdoc />
		public CommonGramsTokenFilterDescriptor CommonWords(IEnumerable<string> commonWords) => Assign(commonWords, (a, v) => a.CommonWords = v);

		/// <inheritdoc />
		public CommonGramsTokenFilterDescriptor CommonWords(params string[] commonWords) => Assign(commonWords, (a, v) => a.CommonWords = v);
	}
}
