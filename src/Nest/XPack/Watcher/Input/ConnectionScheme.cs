using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ConnectionScheme
	{
		[EnumMember(Value = "http")]
		Http,

		[EnumMember(Value = "https")]
		Https
	}
}
