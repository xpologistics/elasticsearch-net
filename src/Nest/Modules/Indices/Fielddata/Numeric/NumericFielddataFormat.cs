using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum NumericFielddataFormat
	{
		[EnumMember(Value = "array")]
		Array,

		[EnumMember(Value = "disabled")]
		Disabled
	}
}
