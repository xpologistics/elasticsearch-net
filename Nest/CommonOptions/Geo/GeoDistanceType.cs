using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum GeoDistanceType
	{
		[EnumMember(Value = "arc")]
		Arc,

		[EnumMember(Value = "plane")]
		Plane
	}
}
