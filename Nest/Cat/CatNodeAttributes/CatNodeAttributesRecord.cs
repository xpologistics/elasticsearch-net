﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class CatNodeAttributesRecord : ICatRecord
	{
		[JsonProperty("attr")]
		public string Attribute { get; set; }

		[JsonProperty("host")]
		public string Host { get; set; }

		// duration indices successful_shards failed_shards total_shards
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("ip")]
		public string Ip { get; set; }

		[JsonProperty("node")]
		public string Node { get; set; }

		[JsonProperty("port")]
		public long Port { get; set; }

		[JsonProperty("pid")]
		public long ProcessId { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}
}
