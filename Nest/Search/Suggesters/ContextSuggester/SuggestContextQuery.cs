﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SuggestContextQuery>))]
	public interface ISuggestContextQuery
	{
		[JsonProperty("boost")]
		double? Boost { get; set; }

		[JsonProperty("context")]
		Context Context { get; set; }

		[JsonProperty("neighbours")]
		Union<Distance[], int[]> Neighbours { get; set; }

		[JsonProperty("precision")]
		Union<Distance, int> Precision { get; set; }

		[JsonProperty("prefix")]
		bool? Prefix { get; set; }
	}

	public class SuggestContextQuery : ISuggestContextQuery
	{
		public double? Boost { get; set; }

		public Context Context { get; set; }

		public Union<Distance[], int[]> Neighbours { get; set; }

		public Union<Distance, int> Precision { get; set; }

		public bool? Prefix { get; set; }
	}

	public class SuggestContextQueryDescriptor<T>
		: DescriptorBase<SuggestContextQueryDescriptor<T>, ISuggestContextQuery>, ISuggestContextQuery
	{
		double? ISuggestContextQuery.Boost { get; set; }
		Context ISuggestContextQuery.Context { get; set; }
		Union<Distance[], int[]> ISuggestContextQuery.Neighbours { get; set; }
		Union<Distance, int> ISuggestContextQuery.Precision { get; set; }
		bool? ISuggestContextQuery.Prefix { get; set; }

		public SuggestContextQueryDescriptor<T> Prefix(bool? prefix = true) => Assign(prefix, (a, v) => a.Prefix = v);

		public SuggestContextQueryDescriptor<T> Boost(double? boost) => Assign(boost, (a, v) => a.Boost = v);

		public SuggestContextQueryDescriptor<T> Context(string context) => Assign(context, (a, v) => a.Context = v);

		public SuggestContextQueryDescriptor<T> Context(GeoLocation context) => Assign(context, (a, v) => a.Context = v);

		public SuggestContextQueryDescriptor<T> Precision(Distance precision) => Assign(precision, (a, v) => a.Precision = v);

		public SuggestContextQueryDescriptor<T> Precision(int? precision) => Assign(precision, (a, v) => a.Precision = v);

		public SuggestContextQueryDescriptor<T> Neighbours(params int[] neighbours) => Assign(neighbours, (a, v) => a.Neighbours = v);

		public SuggestContextQueryDescriptor<T> Neighbours(params Distance[] neighbours) => Assign(neighbours, (a, v) => a.Neighbours = v);
	}

	public class SuggestContextQueriesDescriptor<T>
		: DescriptorPromiseBase<SuggestContextQueriesDescriptor<T>, IDictionary<string, IList<ISuggestContextQuery>>>
	{
		public SuggestContextQueriesDescriptor() : base(new Dictionary<string, IList<ISuggestContextQuery>>()) { }

		public SuggestContextQueriesDescriptor<T> Context(string name,
			params Func<SuggestContextQueryDescriptor<T>, ISuggestContextQuery>[] categoryDescriptors
		) =>
			AddContextQueries(name, categoryDescriptors?.Select(d => d?.Invoke(new SuggestContextQueryDescriptor<T>())).ToList());

		private SuggestContextQueriesDescriptor<T> AddContextQueries(string name, List<ISuggestContextQuery> contextQueries)
		{
			if (contextQueries != null)
				PromisedValue.Add(name, contextQueries);

			return this;
		}
	}
}
