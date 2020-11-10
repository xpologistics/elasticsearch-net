using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardFileSizeInfo
	{
		[JsonProperty("description")]
		public string Description { get; internal set; }

		[JsonProperty("size_in_bytes")]
		public long SizeInBytes { get; internal set; }
	}
}
