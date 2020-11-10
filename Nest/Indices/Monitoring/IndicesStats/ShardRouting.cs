﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardRouting
	{
		[JsonProperty("node")]
		public string Node { get; internal set; }

		[JsonProperty("primary")]
		public bool Primary { get; internal set; }

		[JsonProperty("relocating_node")]
		public string RelocatingNode { get; internal set; }

		[JsonProperty("state")]
		public ShardRoutingState State { get; internal set; }
	}
}
