﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class QueryCacheStats
	{
		[JsonProperty("cache_count")]
		public long CacheCount { get; set; }

		[JsonProperty("cache_size")]
		public long CacheSize { get; set; }

		[JsonProperty("evictions")]
		public long Evictions { get; set; }

		[JsonProperty("hit_count")]
		public long HitCount { get; set; }

		[JsonProperty("memory_size")]
		public string MemorySize { get; set; }

		[JsonProperty("memory_size_in_bytes")]
		public long MemorySizeInBytes { get; set; }

		[JsonProperty("miss_count")]
		public long MissCount { get; set; }

		[JsonProperty("total_count")]
		public long TotalCount { get; set; }
	}
}
