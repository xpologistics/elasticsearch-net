﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class SnapshotShardFailure
	{
		[JsonProperty("index")]
		public string Index { get; set; }

		[JsonProperty("node_id")]
		public string NodeId { get; set; }

		[JsonProperty("reason")]
		public string Reason { get; set; }

		[JsonProperty("shard_id")]
		public string ShardId { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }
	}
}
