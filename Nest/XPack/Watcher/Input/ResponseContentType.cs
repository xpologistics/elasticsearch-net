using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ResponseContentType
	{
		[EnumMember(Value = "json")]
		Json,

		[EnumMember(Value = "yaml")]
		Yaml,

		[EnumMember(Value = "text")]
		Text
	}
}