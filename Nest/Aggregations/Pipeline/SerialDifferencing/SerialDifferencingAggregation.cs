﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<SerialDifferencingAggregation>))]
	public interface ISerialDifferencingAggregation : IPipelineAggregation
	{
		[JsonProperty("lag")]
		int? Lag { get; set; }
	}

	public class SerialDifferencingAggregation : PipelineAggregationBase, ISerialDifferencingAggregation
	{
		internal SerialDifferencingAggregation() { }

		public SerialDifferencingAggregation(string name, SingleBucketsPath bucketsPath)
			: base(name, bucketsPath) { }

		public int? Lag { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.SerialDifferencing = this;
	}

	public class SerialDifferencingAggregationDescriptor
		: PipelineAggregationDescriptorBase<SerialDifferencingAggregationDescriptor, ISerialDifferencingAggregation, SingleBucketsPath>
			, ISerialDifferencingAggregation
	{
		int? ISerialDifferencingAggregation.Lag { get; set; }

		public SerialDifferencingAggregationDescriptor Lag(int? lag) => Assign(lag, (a, v) => a.Lag = v);
	}
}
