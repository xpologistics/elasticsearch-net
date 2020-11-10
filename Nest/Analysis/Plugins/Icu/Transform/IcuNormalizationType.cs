﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	/// <summary>
	/// Forward (default) for LTR and reverse for RTL
	/// </summary>
	/// <remarks>
	/// Requires analysis-icu plugin to be installed
	/// </remarks>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum IcuTransformDirection
	{
		/// <summary>LTR</summary>
		[EnumMember(Value = "forward")]
		Forward,

		/// <summary> RTL</summary>
		[EnumMember(Value = "reverse")]
		Reverse,
	}
}
