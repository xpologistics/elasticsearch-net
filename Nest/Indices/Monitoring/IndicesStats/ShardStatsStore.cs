using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardStatsStore
	{
		[JsonProperty("size_in_bytes")]
		public long SizeInBytes { get; internal set; }
	}
}
