﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface IGeoSuggestContext : ISuggestContext
	{
		[JsonProperty("neighbors")]
		bool? Neighbors { get; set; }

		[JsonProperty("precision")]
		IEnumerable<string> Precision { get; set; }
	}

	[JsonObject]
	public class GeoSuggestContext : SuggestContextBase, IGeoSuggestContext
	{
		public bool? Neighbors { get; set; }

		public IEnumerable<string> Precision { get; set; }
		public override string Type => "geo";
	}

	public class GeoSuggestContextDescriptor<T>
		: SuggestContextDescriptorBase<GeoSuggestContextDescriptor<T>, IGeoSuggestContext, T>, IGeoSuggestContext
		where T : class
	{
		protected override string Type => "geo";
		bool? IGeoSuggestContext.Neighbors { get; set; }
		IEnumerable<string> IGeoSuggestContext.Precision { get; set; }

		public GeoSuggestContextDescriptor<T> Precision(params string[] precisions) => Assign(precisions, (a, v) => a.Precision = v);

		public GeoSuggestContextDescriptor<T> Neighbors(bool? neighbors = true) => Assign(neighbors, (a, v) => a.Neighbors = v);
	}
}
