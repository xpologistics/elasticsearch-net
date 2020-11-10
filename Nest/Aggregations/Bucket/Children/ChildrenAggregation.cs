﻿using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<ChildrenAggregation>))]
	public interface IChildrenAggregation : IBucketAggregation
	{
		[JsonProperty("type")]
		RelationName Type { get; set; }
	}

	public class ChildrenAggregation : BucketAggregationBase, IChildrenAggregation
	{
		internal ChildrenAggregation() { }

		public ChildrenAggregation(string name, RelationName type) : base(name) => Type = type;

		public RelationName Type { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Children = this;
	}

	public class ChildrenAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<ChildrenAggregationDescriptor<T>, IChildrenAggregation, T>, IChildrenAggregation
		where T : class
	{
		RelationName IChildrenAggregation.Type { get; set; } = typeof(T);

		public ChildrenAggregationDescriptor<T> Type(RelationName type) =>
			Assign(type, (a, v) => a.Type = v);

		public ChildrenAggregationDescriptor<T> Type<TChildType>() where TChildType : class =>
			Assign(typeof(TChildType), (a, v) => a.Type = v);
	}
}
