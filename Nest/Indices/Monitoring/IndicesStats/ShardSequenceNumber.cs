using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardSequenceNumber
	{
		[JsonProperty("global_checkpoint")]
		public long GlobalCheckpoint { get; internal set; }

		[JsonProperty("local_checkpoint")]
		public long LocalCheckpoint { get; internal set; }

		[JsonProperty("max_seq_no")]
		public long MaximumSequenceNumber { get; internal set; }
	}
}
