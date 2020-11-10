﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// The pattern_capture token filter, unlike the pattern tokenizer, emits a token for every capture group in the regular expression.
	/// </summary>
	public interface IPatternCaptureTokenFilter : ITokenFilter
	{
		/// <summary>
		/// The regular expression patterns to capture
		/// </summary>
		[JsonProperty("patterns")]
		IEnumerable<string> Patterns { get; set; }

		/// <summary>
		/// If preserve_original is set to true then it would also emit the original token
		/// </summary>
		[JsonProperty("preserve_original")]
		bool? PreserveOriginal { get; set; }
	}

	/// <inheritdoc />
	public class PatternCaptureTokenFilter : TokenFilterBase, IPatternCaptureTokenFilter
	{
		public PatternCaptureTokenFilter() : base("pattern_capture") { }

		/// <inheritdoc />
		public IEnumerable<string> Patterns { get; set; }

		/// <inheritdoc />
		public bool? PreserveOriginal { get; set; }
	}

	/// <inheritdoc />
	public class PatternCaptureTokenFilterDescriptor
		: TokenFilterDescriptorBase<PatternCaptureTokenFilterDescriptor, IPatternCaptureTokenFilter>, IPatternCaptureTokenFilter
	{
		protected override string Type => "pattern_capture";
		IEnumerable<string> IPatternCaptureTokenFilter.Patterns { get; set; }

		bool? IPatternCaptureTokenFilter.PreserveOriginal { get; set; }

		/// <inheritdoc />
		public PatternCaptureTokenFilterDescriptor PreserveOriginal(bool? preserve = true) => Assign(preserve, (a, v) => a.PreserveOriginal = v);

		/// <inheritdoc />
		public PatternCaptureTokenFilterDescriptor Patterns(IEnumerable<string> patterns) => Assign(patterns, (a, v) => a.Patterns = v);

		/// <inheritdoc />
		public PatternCaptureTokenFilterDescriptor Patterns(params string[] patterns) => Assign(patterns, (a, v) => a.Patterns = v);
	}
}
