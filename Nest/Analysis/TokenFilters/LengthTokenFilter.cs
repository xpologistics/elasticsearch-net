﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A token filter of type length that removes words that are too long or too short for the stream.
	/// </summary>
	public interface ILengthTokenFilter : ITokenFilter
	{
		/// <summary>
		/// The maximum number. Defaults to Integer.MAX_VALUE.
		/// </summary>
		[JsonProperty("max")]
		int? Max { get; set; }

		/// <summary>
		/// The minimum number. Defaults to 0.
		/// </summary>
		[JsonProperty("min")]
		int? Min { get; set; }
	}

	/// <inheritdoc />
	public class LengthTokenFilter : TokenFilterBase, ILengthTokenFilter
	{
		public LengthTokenFilter() : base("length") { }

		/// <inheritdoc />
		public int? Max { get; set; }

		/// <inheritdoc />
		public int? Min { get; set; }
	}

	/// <inheritdoc />
	public class LengthTokenFilterDescriptor
		: TokenFilterDescriptorBase<LengthTokenFilterDescriptor, ILengthTokenFilter>, ILengthTokenFilter
	{
		protected override string Type => "length";
		int? ILengthTokenFilter.Max { get; set; }

		int? ILengthTokenFilter.Min { get; set; }

		/// <inheritdoc />
		public LengthTokenFilterDescriptor Min(int? minimum) => Assign(minimum, (a, v) => a.Min = v);

		/// <inheritdoc />
		public LengthTokenFilterDescriptor Max(int? maximum) => Assign(maximum, (a, v) => a.Max = v);
	}
}
