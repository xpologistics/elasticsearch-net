﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PhoneticNameType
	{
		[EnumMember(Value = "generic")]
		Generic,

		[EnumMember(Value = "ashkenazi")]
		Ashkenazi,

		[EnumMember(Value = "sephardic")]
		Sephardic
	}
}
