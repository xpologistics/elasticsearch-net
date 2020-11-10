﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class HitsMetadata<T> where T : class
	{
		[JsonProperty("hits")]
		public IReadOnlyCollection<IHit<T>> Hits { get; internal set; } = EmptyReadOnly<IHit<T>>.Collection;

		[JsonProperty("max_score")]
		public double MaxScore { get; internal set; }

		[JsonProperty("total")]
		public long Total { get; internal set; }
	}
}
