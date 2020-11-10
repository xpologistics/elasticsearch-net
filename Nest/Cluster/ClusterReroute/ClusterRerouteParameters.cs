﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ClusterRerouteParameters
	{
		[JsonProperty("allow_primary")]
		public bool? AllowPrimary { get; set; }

		[JsonProperty("from_node")]
		public string FromNode { get; set; }

		[JsonProperty("index")]
		public string Index { get; set; }

		[JsonProperty("node")]
		public string Node { get; set; }

		[JsonProperty("shard")]
		public int Shard { get; set; }

		[JsonProperty("to_node")]
		public string ToNode { get; set; }
	}
}
