using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(RangeQueryJsonConverter))]
	public interface IRangeQuery : IFieldNameQuery { }
}
