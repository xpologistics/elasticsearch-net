﻿using Newtonsoft.Json;

namespace Nest6
{
	public class AliasDefinition
	{
		[JsonProperty("filter")]
		public IQueryContainer Filter { get; internal set; }

		[JsonProperty("index_routing")]
		public string IndexRouting { get; internal set; }

		[JsonProperty("is_write_index")]
		public bool? IsWriteIndex { get; internal set; }

		[JsonProperty("routing")]
		public string Routing { get; internal set; }

		[JsonProperty("search_routing")]
		public string SearchRouting { get; internal set; }
	}
}
