﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[JsonConverter(typeof(BulkResponseItemJsonConverter))]
	public class BulkIndexResponseItem : BulkResponseItemBase
	{
		/// <summary>
		/// The _ids that matched (if any) for the Percolate API.
		/// Will be null if the operation is not in response to Percolate API.
		/// </summary>
		[JsonProperty("matches")]
		public IEnumerable<string> Matches { get; internal set; }

		public override string Operation { get; internal set; }
	}
}
