using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<IpRangeAggregation>))]
	public interface IIpRangeAggregation : IBucketAggregation
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("ranges")]
		IEnumerable<IIpRange> Ranges { get; set; }
	}

	public class IpRangeAggregation : BucketAggregationBase, IIpRangeAggregation
	{
		internal IpRangeAggregation() { }

		public IpRangeAggregation(string name) : base(name) { }

		public Field Field { get; set; }
		public IEnumerable<IIpRange> Ranges { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.IpRange = this;
	}

	public class IpRangeAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<IpRangeAggregationDescriptor<T>, IIpRangeAggregation, T>
			, IIpRangeAggregation
		where T : class
	{
		Field IIpRangeAggregation.Field { get; set; }

		IEnumerable<IIpRange> IIpRangeAggregation.Ranges { get; set; }

		public IpRangeAggregationDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public IpRangeAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(field, (a, v) => a.Field = v);

		public IpRangeAggregationDescriptor<T> Ranges(params Func<IpRangeDescriptor, IIpRange>[] ranges) =>
			Assign(ranges?.Select(r => r(new IpRangeDescriptor())), (a, v) => a.Ranges = v);
	}
}
