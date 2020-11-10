﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class Suggest<T> where T : class
	{
		[JsonProperty("length")]
		public int Length { get; internal set; }

		[JsonProperty("offset")]
		public int Offset { get; internal set; }

		[JsonProperty("options")]
		public IReadOnlyCollection<SuggestOption<T>> Options { get; internal set; } = EmptyReadOnly<SuggestOption<T>>.Collection;

		[JsonProperty("text")]
		public string Text { get; internal set; }
	}
}
