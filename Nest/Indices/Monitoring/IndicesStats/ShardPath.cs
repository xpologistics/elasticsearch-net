﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ShardPath
	{
		[JsonProperty("data_path")]
		public string DataPath { get; internal set; }

		[JsonProperty("is_custom_data_path")]
		public bool IsCustomDataPath { get; internal set; }

		[JsonProperty("state_path")]
		public string StatePath { get; internal set; }
	}
}
