using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardFieldData
	{
		[JsonProperty("evictions")]
		public long Evictions { get; internal set; }

		[JsonProperty("memory_size_in_bytes")]
		public long MemorySizeInBytes { get; internal set; }
	}
}
