using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum PhoneticRuleType
	{
		[EnumMember(Value = "approx")]
		Approximate,

		[EnumMember(Value = "exact")]
		Exact
	}
}
