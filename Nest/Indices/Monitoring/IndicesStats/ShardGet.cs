﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardGet
	{
		[JsonProperty("current")]
		public long Current { get; internal set; }

		[JsonProperty("exists_time_in_millis")]
		public long ExistsTimeInMilliseconds { get; internal set; }

		[JsonProperty("exists_total")]
		public long ExistsTotal { get; internal set; }

		[JsonProperty("missing_time_in_millis")]
		public long MissingTimeInMilliseconds { get; internal set; }

		[JsonProperty("missing_total")]
		public long MissingTotal { get; internal set; }

		[JsonProperty("time_in_millis")]
		public long TimeInMilliseconds { get; internal set; }

		[JsonProperty("total")]
		public long Total { get; internal set; }
	}
}
