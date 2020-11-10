﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// The synonym token filter allows to easily handle synonyms during the analysis process.
	/// </summary>
	public interface ISynonymTokenFilter : ITokenFilter
	{
		[JsonProperty("expand")]
		bool? Expand { get; set; }

		[JsonProperty("format")]
		SynonymFormat? Format { get; set; }

		[JsonProperty("ignore_case")]
		[Obsolete("Will be removed in Elasticsearch 7.x, if you need to ignore case add a lowercase filter before this synonym filter")]
		bool? IgnoreCase { get; set; }

		/// <summary>
		/// If `true` ignores exceptions while parsing the synonym configuration. It is important
		// to note that only those synonym rules which cannot get parsed are ignored.
		/// </summary>
		[JsonProperty("lenient")]
		bool? Lenient { get; set; }

		[JsonProperty("synonyms")]
		IEnumerable<string> Synonyms { get; set; }

		/// <summary>
		///  a path a synonyms file relative to the node's `config` location.
		/// </summary>
		[JsonProperty("synonyms_path")]
		string SynonymsPath { get; set; }

		[JsonProperty("tokenizer")]
		string Tokenizer { get; set; }
	}

	/// <inheritdoc />
	public class SynonymTokenFilter : TokenFilterBase, ISynonymTokenFilter
	{
		public SynonymTokenFilter() : base("synonym") { }

		/// <inheritdoc />
		public bool? Expand { get; set; }

		/// <inheritdoc />
		public SynonymFormat? Format { get; set; }

		/// <inheritdoc />
		[Obsolete("Will be removed in Elasticsearch 7.x, if you need to ignore case add a lowercase filter before this synonym filter")]
		public bool? IgnoreCase { get; set; }

		/// <inheritdoc cref="ISynonymTokenFilter.Lenient" />
		public bool? Lenient { get; set; }

		/// <inheritdoc />
		public IEnumerable<string> Synonyms { get; set; }

		/// <inheritdoc />
		public string SynonymsPath { get; set; }

		/// <inheritdoc />
		public string Tokenizer { get; set; }
	}

	/// <inheritdoc />
	public class SynonymTokenFilterDescriptor
		: TokenFilterDescriptorBase<SynonymTokenFilterDescriptor, ISynonymTokenFilter>, ISynonymTokenFilter
	{
		protected override string Type => "synonym";
		bool? ISynonymTokenFilter.Expand { get; set; }
		SynonymFormat? ISynonymTokenFilter.Format { get; set; }

		bool? ISynonymTokenFilter.IgnoreCase { get; set; }
		bool? ISynonymTokenFilter.Lenient { get; set; }
		IEnumerable<string> ISynonymTokenFilter.Synonyms { get; set; }
		string ISynonymTokenFilter.SynonymsPath { get; set; }
		string ISynonymTokenFilter.Tokenizer { get; set; }

		/// <inheritdoc />
		[Obsolete("Will be removed in Elasticsearch 7.x, if you need to ignore case add a lowercase filter before this synonym filter")]
		public SynonymTokenFilterDescriptor IgnoreCase(bool? ignoreCase = true) => Assign(ignoreCase, (a, v) => a.IgnoreCase = v);

		/// <inheritdoc />
		public SynonymTokenFilterDescriptor Expand(bool? expand = true) => Assign(expand, (a, v) => a.Expand = v);

		/// <inheritdoc cref="ISynonymTokenFilter.Lenient" />
		public SynonymTokenFilterDescriptor Lenient(bool? lenient = true) => Assign(lenient, (a, v) => a.Lenient = v);

		/// <inheritdoc />
		public SynonymTokenFilterDescriptor Tokenizer(string tokenizer) => Assign(tokenizer, (a, v) => a.Tokenizer = v);

		/// <inheritdoc />
		public SynonymTokenFilterDescriptor SynonymsPath(string path) => Assign(path, (a, v) => a.SynonymsPath = v);

		/// <inheritdoc />
		public SynonymTokenFilterDescriptor Format(SynonymFormat? format) => Assign(format, (a, v) => a.Format = v);

		/// <inheritdoc />
		public SynonymTokenFilterDescriptor Synonyms(IEnumerable<string> synonyms) => Assign(synonyms, (a, v) => a.Synonyms = v);

		/// <inheritdoc />
		public SynonymTokenFilterDescriptor Synonyms(params string[] synonyms) => Assign(synonyms, (a, v) => a.Synonyms = v);
	}
}
