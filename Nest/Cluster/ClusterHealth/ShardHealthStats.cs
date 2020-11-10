﻿using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardHealthStats
	{
		[JsonProperty("active_shards")]
		public int ActiveShards { get; internal set; }

		[JsonProperty("initializing_shards")]
		public int InitializingShards { get; internal set; }

		[JsonProperty("primary_active")]
		public bool PrimaryActive { get; internal set; }

		[JsonProperty("relocating_shards")]
		public int RelocatingShards { get; internal set; }

		[JsonProperty("status")]
		public Health Status { get; internal set; }

		[JsonProperty("unassigned_shards")]
		public int UnassignedShards { get; internal set; }
	}
}
