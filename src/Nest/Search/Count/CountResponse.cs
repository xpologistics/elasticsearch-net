using Newtonsoft.Json;

namespace Nest6
{
	public interface ICountResponse : IResponse
	{
		long Count { get; }
		ShardStatistics Shards { get; }
	}

	[JsonObject]
	public class CountResponse : ResponseBase, ICountResponse
	{
		[JsonProperty("count")]
		public long Count { get; internal set; }

		[JsonProperty("_shards")]
		public ShardStatistics Shards { get; internal set; }
	}
}
