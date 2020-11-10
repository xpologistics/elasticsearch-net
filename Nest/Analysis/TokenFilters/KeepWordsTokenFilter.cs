﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A token filter of type keep that only keeps tokens with text contained in a predefined set of words.
	/// </summary>
	public interface IKeepWordsTokenFilter : ITokenFilter
	{
		/// <summary>
		/// A list of words to keep.
		/// </summary>
		[JsonProperty("keep_words")]
		IEnumerable<string> KeepWords { get; set; }

		/// <summary>
		/// A boolean indicating whether to lower case the words.
		/// </summary>
		[JsonProperty("keep_words_case")]
		bool? KeepWordsCase { get; set; }

		/// <summary>
		/// A path to a words file.
		/// </summary>
		[JsonProperty("keep_words_path")]
		string KeepWordsPath { get; set; }
	}

	/// <inheritdoc />
	public class KeepWordsTokenFilter : TokenFilterBase, IKeepWordsTokenFilter
	{
		public KeepWordsTokenFilter() : base("keep") { }

		/// <inheritdoc />
		public IEnumerable<string> KeepWords { get; set; }

		/// <inheritdoc />
		public bool? KeepWordsCase { get; set; }

		/// <inheritdoc />
		public string KeepWordsPath { get; set; }
	}

	/// <inheritdoc />
	public class KeepWordsTokenFilterDescriptor
		: TokenFilterDescriptorBase<KeepWordsTokenFilterDescriptor, IKeepWordsTokenFilter>, IKeepWordsTokenFilter
	{
		protected override string Type => "keep";
		IEnumerable<string> IKeepWordsTokenFilter.KeepWords { get; set; }

		bool? IKeepWordsTokenFilter.KeepWordsCase { get; set; }
		string IKeepWordsTokenFilter.KeepWordsPath { get; set; }

		/// <inheritdoc />
		public KeepWordsTokenFilterDescriptor KeepWordsCase(bool? keepCase = true) => Assign(keepCase, (a, v) => a.KeepWordsCase = v);

		/// <inheritdoc />
		public KeepWordsTokenFilterDescriptor KeepWordsPath(string path) => Assign(path, (a, v) => a.KeepWordsPath = v);

		/// <inheritdoc />
		public KeepWordsTokenFilterDescriptor KeepWords(IEnumerable<string> keepWords) => Assign(keepWords, (a, v) => a.KeepWords = v);

		/// <inheritdoc />
		public KeepWordsTokenFilterDescriptor KeepWords(params string[] keepWords) => Assign(keepWords, (a, v) => a.KeepWords = v);
	}
}
