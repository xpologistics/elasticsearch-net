using Newtonsoft.Json;

namespace Nest6
{
	public interface IIndicesResponse : IResponse
	{
		bool Acknowledged { get; }
		ShardStatistics ShardsHit { get; }
	}

	[JsonObject]
	public abstract class IndicesResponseBase : ResponseBase, IIndicesResponse
	{
		[JsonProperty("acknowledged")]
		public bool Acknowledged { get; private set; }

		[JsonProperty("_shards")]
		public ShardStatistics ShardsHit { get; private set; }
	}
}
