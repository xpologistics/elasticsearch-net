using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(FilterAggregationJsonConverter))]
	public interface IFilterAggregation : IBucketAggregation
	{
		[JsonProperty("filter")]
		QueryContainer Filter { get; set; }
	}

	public class FilterAggregation : BucketAggregationBase, IFilterAggregation
	{
		internal FilterAggregation() { }

		public FilterAggregation(string name) : base(name) { }

		public QueryContainer Filter { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Filter = this;
	}

	public class FilterAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<FilterAggregationDescriptor<T>, IFilterAggregation, T>
			, IFilterAggregation
		where T : class
	{
		QueryContainer IFilterAggregation.Filter { get; set; }

		public FilterAggregationDescriptor<T> Filter(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(selector, (a, v) => a.Filter = v?.Invoke(new QueryContainerDescriptor<T>()));
	}
}
