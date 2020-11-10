﻿using Newtonsoft.Json;

namespace Nest6
{
	public class RecoveryIndexStatus
	{
		[JsonProperty("bytes")]
		public RecoveryBytes Bytes { get; internal set; }

		[JsonProperty("files")]
		public RecoveryFiles Files { get; internal set; }

		[JsonProperty("total_time_in_millis")]
		public long TotalTimeInMilliseconds { get; internal set; }
	}
}
