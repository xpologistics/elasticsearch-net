﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<CompletionSuggester>))]
	public interface ICompletionSuggester : ISuggester
	{
		/// <summary>
		/// Context mappings used to filter and/or boost suggestions
		/// </summary>
		[JsonProperty("contexts")]
		IDictionary<string, IList<ISuggestContextQuery>> Contexts { get; set; }

		/// <summary>
		/// Support fuzziness for the suggestions
		/// </summary>
		[JsonProperty("fuzzy")]
		IFuzzySuggester Fuzzy { get; set; }

		/// <summary>
		/// Prefix used to search for suggestions
		/// </summary>
		[JsonIgnore]
		string Prefix { get; set; }

		/// <summary>
		/// Prefix as a regular expression used to search for suggestions
		/// </summary>
		[JsonIgnore]
		string Regex { get; set; }

		/// <summary>
		/// Whether duplicate suggestions should be filtered out. Defaults to <c>false</c>
		/// </summary>
		/// <remarks>Only available in Elasticsearch 6.1.0+</remarks>
		[JsonProperty("skip_duplicates")]
		bool? SkipDuplicates { get; set; }
	}

	public class CompletionSuggester : SuggesterBase, ICompletionSuggester
	{
		/// <inheritdoc />
		public IDictionary<string, IList<ISuggestContextQuery>> Contexts { get; set; }

		/// <inheritdoc />
		public IFuzzySuggester Fuzzy { get; set; }

		/// <inheritdoc />
		public string Prefix { get; set; }

		/// <inheritdoc />
		public string Regex { get; set; }

		/// <inheritdoc />
		public bool? SkipDuplicates { get; set; }
	}

	public class CompletionSuggesterDescriptor<T>
		: SuggestDescriptorBase<CompletionSuggesterDescriptor<T>, ICompletionSuggester, T>, ICompletionSuggester
		where T : class
	{
		IDictionary<string, IList<ISuggestContextQuery>> ICompletionSuggester.Contexts { get; set; }
		IFuzzySuggester ICompletionSuggester.Fuzzy { get; set; }
		string ICompletionSuggester.Prefix { get; set; }
		string ICompletionSuggester.Regex { get; set; }
		bool? ICompletionSuggester.SkipDuplicates { get; set; }

		/// <summary>
		/// Prefix used to search for suggestions
		/// </summary>
		public CompletionSuggesterDescriptor<T> Prefix(string prefix) => Assign(prefix, (a, v) => a.Prefix = v);

		/// <summary>
		/// Prefix as a regular expression used to search for suggestions
		/// </summary>
		public CompletionSuggesterDescriptor<T> Regex(string regex) => Assign(regex, (a, v) => a.Regex = v);

		/// <summary>
		/// Support fuzziness for the suggestions
		/// </summary>
		public CompletionSuggesterDescriptor<T> Fuzzy(Func<FuzzySuggestDescriptor<T>, IFuzzySuggester> selector = null) =>
			Assign(selector.InvokeOrDefault(new FuzzySuggestDescriptor<T>()), (a, v) => a.Fuzzy = v);

		/// <summary>
		/// Context mappings used to filter and/or boost suggestions
		/// </summary>
		public CompletionSuggesterDescriptor<T> Contexts(
			Func<SuggestContextQueriesDescriptor<T>, IPromise<IDictionary<string, IList<ISuggestContextQuery>>>> contexts
		) =>
			Assign(contexts, (a, v) => a.Contexts = v?.Invoke(new SuggestContextQueriesDescriptor<T>()).Value);

		/// <summary>
		/// Whether duplicate suggestions should be filtered out. Defaults to <c>false</c>
		/// </summary>
		/// <remarks>Only available in Elasticsearch 6.1.0+</remarks>
		public CompletionSuggesterDescriptor<T> SkipDuplicates(bool? skipDuplicates = true) => Assign(skipDuplicates, (a, v) => a.SkipDuplicates = v);
	}
}
