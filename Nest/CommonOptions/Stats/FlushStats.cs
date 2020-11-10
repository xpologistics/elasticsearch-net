﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class FlushStats
	{
		/// <summary>
		/// The number of flushes that were periodically triggered when translog exceeded the flush threshold.
		/// </summary>
		[JsonProperty("periodic")]
		public long Periodic { get; set; }

		[JsonProperty("total")]
		public long Total { get; set; }

		/// <summary>
		/// The total time merges have been executed.
		/// </summary>
		[JsonProperty("total_time")]
		public string TotalTime { get; set; }

		/// <summary>
		/// The total time merges have been executed (in milliseconds).
		/// </summary>
		[JsonProperty("total_time_in_millis")]
		public long TotalTimeInMilliseconds { get; set; }
	}
}
