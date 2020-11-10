﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<ReverseNestedAggregation>))]
	public interface IReverseNestedAggregation : IBucketAggregation
	{
		[JsonProperty("path")]
		Field Path { get; set; }
	}

	public class ReverseNestedAggregation : BucketAggregationBase, IReverseNestedAggregation
	{
		internal ReverseNestedAggregation() { }

		public ReverseNestedAggregation(string name) : base(name) { }

		[JsonProperty("path")]
		public Field Path { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.ReverseNested = this;
	}

	public class ReverseNestedAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<ReverseNestedAggregationDescriptor<T>, IReverseNestedAggregation, T>
			, IReverseNestedAggregation
		where T : class
	{
		Field IReverseNestedAggregation.Path { get; set; }

		public ReverseNestedAggregationDescriptor<T> Path(Field path) => Assign(path, (a, v) => a.Path = v);

		public ReverseNestedAggregationDescriptor<T> Path(Expression<Func<T, object>> path) => Assign(path, (a, v) => a.Path = v);
	}
}
