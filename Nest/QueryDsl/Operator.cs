using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Operator
	{
		[EnumMember(Value = "and")]
		And,

		[EnumMember(Value = "or")]
		Or
	}
}
