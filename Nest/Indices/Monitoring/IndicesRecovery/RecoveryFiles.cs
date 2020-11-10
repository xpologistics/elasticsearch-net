﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public class RecoveryFiles
	{
		[JsonProperty("details")]
		public IEnumerable<RecoveryFileDetails> Details { get; internal set; }

		[JsonProperty("percent")]
		public string Percent { get; internal set; }

		[JsonProperty("recovered")]
		public long Recovered { get; internal set; }

		[JsonProperty("reused")]
		public long Reused { get; internal set; }

		[JsonProperty("total")]
		public long Total { get; internal set; }
	}
}
