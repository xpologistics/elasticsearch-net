﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// The pattern_replace char filter allows the use of a regex to manipulate the characters in a string before analysis.
	/// </summary>
	public interface IPatternReplaceCharFilter : ICharFilter
	{
		[JsonProperty("pattern")]
		string Pattern { get; set; }

		[JsonProperty("replacement")]
		string Replacement { get; set; }
	}

	/// <inheritdoc />
	public class PatternReplaceCharFilter : CharFilterBase, IPatternReplaceCharFilter
	{
		public PatternReplaceCharFilter() : base("pattern_replace") { }

		/// <inheritdoc />
		public string Pattern { get; set; }

		/// <inheritdoc />
		public string Replacement { get; set; }
	}

	/// <inheritdoc />
	public class PatternReplaceCharFilterDescriptor
		: CharFilterDescriptorBase<PatternReplaceCharFilterDescriptor, IPatternReplaceCharFilter>, IPatternReplaceCharFilter
	{
		protected override string Type => "pattern_replace";
		string IPatternReplaceCharFilter.Pattern { get; set; }
		string IPatternReplaceCharFilter.Replacement { get; set; }

		/// <inheritdoc />
		public PatternReplaceCharFilterDescriptor Pattern(string pattern) =>
			Assign(pattern, (a, v) => a.Pattern = v);

		/// <inheritdoc />
		public PatternReplaceCharFilterDescriptor Replacement(string replacement) =>
			Assign(replacement, (a, v) => a.Replacement = v);
	}
}
