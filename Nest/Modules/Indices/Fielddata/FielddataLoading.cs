﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum FielddataLoading
	{
		[EnumMember(Value = "eager")]
		Eager,

		[EnumMember(Value = "eager_global_ordinals")]
		EagerGlobalOrdinals
	}
}
