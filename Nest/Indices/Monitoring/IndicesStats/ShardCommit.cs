﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardCommit
	{
		[JsonProperty("generation")]
		public int Generation { get; internal set; }

		[JsonProperty("id")]
		public string Id { get; internal set; }

		[JsonProperty("num_docs")]
		public long NumberOfDocuments { get; internal set; }

		[JsonProperty("user_data")]
		public IReadOnlyDictionary<string, string> UserData { get; internal set; }
	}
}
