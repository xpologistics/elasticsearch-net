﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	/// <summary>
	/// Normalization mode https://en.wikipedia.org/wiki/Unicode_equivalence#Normal_forms
	/// </summary>
	/// <remarks>
	/// Requires analysis-icu plugin to be installed
	/// </remarks>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum IcuNormalizationMode
	{
		/// <summary>
		/// Switch normalization type to decompose
		/// </summary>
		[EnumMember(Value = "decompose")]
		Decompose,

		/// <summary>
		/// Switch normalization type to compose, which is the default so you'd never need to set this
		/// Included here for completeness sake because the Java API has it.
		/// </summary>
		[EnumMember(Value = "compose")]
		Compose
	}
}
