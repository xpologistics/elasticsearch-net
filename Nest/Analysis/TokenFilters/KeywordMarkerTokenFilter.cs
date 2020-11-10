﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Protects words from being modified by stemmers. Must be placed before any stemming filters.
	/// </summary>
	public interface IKeywordMarkerTokenFilter : ITokenFilter
	{
		/// <summary>
		/// Set to true to lower case all words first. Defaults to false.
		/// </summary>
		[JsonProperty("ignore_case")]
		bool? IgnoreCase { get; set; }

		/// <summary>
		/// A list of words to use.
		/// <para></para>
		/// Cannot specify both <see cref="KeywordsPattern"/> and <see cref="Keywords"/> or <see cref="KeywordsPath"/>
		/// </summary>
		[JsonProperty("keywords")]
		IEnumerable<string> Keywords { get; set; }

		/// <summary>
		/// A path (either relative to config location, or absolute) to a list of words.
		/// <para></para>
		/// Cannot specify both <see cref="KeywordsPattern"/> and <see cref="Keywords"/> or <see cref="KeywordsPath"/>
		/// </summary>
		[JsonProperty("keywords_path")]
		string KeywordsPath { get; set; }

		/// <summary>
		/// A regular expression pattern to match against words in the text.
		/// <para></para>
		/// Cannot specify both <see cref="KeywordsPattern"/> and <see cref="Keywords"/> or <see cref="KeywordsPath"/>
		/// </summary>
		[JsonProperty("keywords_pattern")]
		string KeywordsPattern { get; set; }
	}

	/// <inheritdoc />
	public class KeywordMarkerTokenFilter : TokenFilterBase, IKeywordMarkerTokenFilter
	{
		public KeywordMarkerTokenFilter() : base("keyword_marker") { }

		/// <inheritdoc />
		public bool? IgnoreCase { get; set; }

		/// <inheritdoc />
		public IEnumerable<string> Keywords { get; set; }

		/// <inheritdoc />
		public string KeywordsPath { get; set; }

		/// <inheritdoc />
		public string KeywordsPattern { get; set; }
	}

	/// <inheritdoc />
	public class KeywordMarkerTokenFilterDescriptor
		: TokenFilterDescriptorBase<KeywordMarkerTokenFilterDescriptor, IKeywordMarkerTokenFilter>, IKeywordMarkerTokenFilter
	{
		protected override string Type => "keyword_marker";
		bool? IKeywordMarkerTokenFilter.IgnoreCase { get; set; }

		IEnumerable<string> IKeywordMarkerTokenFilter.Keywords { get; set; }
		string IKeywordMarkerTokenFilter.KeywordsPath { get; set; }

		string IKeywordMarkerTokenFilter.KeywordsPattern { get; set; }

		/// <inheritdoc />
		public KeywordMarkerTokenFilterDescriptor IgnoreCase(bool? ignoreCase = true) => Assign(ignoreCase, (a, v) => a.IgnoreCase = v);

		/// <inheritdoc />
		public KeywordMarkerTokenFilterDescriptor KeywordsPath(string path) => Assign(path, (a, v) => a.KeywordsPath = v);

		/// <inheritdoc />
		public KeywordMarkerTokenFilterDescriptor KeywordsPattern(string pattern) => Assign(pattern, (a, v) => a.KeywordsPattern = v);

		/// <inheritdoc />
		public KeywordMarkerTokenFilterDescriptor Keywords(IEnumerable<string> keywords) => Assign(keywords, (a, v) => a.Keywords = v);

		/// <inheritdoc />
		public KeywordMarkerTokenFilterDescriptor Keywords(params string[] keywords) => Assign(keywords, (a, v) => a.Keywords = v);
	}
}
