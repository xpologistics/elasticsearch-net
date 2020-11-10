﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class IndexStats
	{
		[JsonProperty("completion")]
		public CompletionStats Completion { get; set; }

		[JsonProperty("docs")]
		public DocStats Documents { get; set; }

		[JsonProperty("fielddata")]
		public FielddataStats Fielddata { get; set; }

		[JsonProperty("flush")]
		public FlushStats Flush { get; set; }

		[JsonProperty("get")]
		public GetStats Get { get; set; }

		[JsonProperty("indexing")]
		public IndexingStats Indexing { get; set; }

		[JsonProperty("merges")]
		public MergesStats Merges { get; set; }

		[JsonProperty("query_cache")]
		public QueryCacheStats QueryCache { get; set; }

		[JsonProperty("recovery")]
		public RecoveryStats Recovery { get; set; }

		[JsonProperty("refresh")]
		public RefreshStats Refresh { get; set; }

		[JsonProperty("request_cache")]
		public RequestCacheStats RequestCache { get; set; }

		[JsonProperty("search")]
		public SearchStats Search { get; set; }

		[JsonProperty("segments")]
		public SegmentsStats Segments { get; set; }

		[JsonProperty("store")]
		public StoreStats Store { get; set; }

		[JsonProperty("translog")]
		public TranslogStats Translog { get; set; }

		[JsonProperty("warmer")]
		public WarmerStats Warmer { get; set; }
	}
}
