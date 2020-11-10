﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<PercentilesBucketAggregation>))]
	public interface IPercentilesBucketAggregation : IPipelineAggregation
	{
		[JsonProperty("percents")]
		IEnumerable<double> Percents { get; set; }
	}

	public class PercentilesBucketAggregation
		: PipelineAggregationBase, IPercentilesBucketAggregation
	{
		internal PercentilesBucketAggregation() { }

		public PercentilesBucketAggregation(string name, SingleBucketsPath bucketsPath)
			: base(name, bucketsPath) { }

		public IEnumerable<double> Percents { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.PercentilesBucket = this;
	}

	public class PercentilesBucketAggregationDescriptor
		: PipelineAggregationDescriptorBase<PercentilesBucketAggregationDescriptor, IPercentilesBucketAggregation, SingleBucketsPath>
			, IPercentilesBucketAggregation
	{
		IEnumerable<double> IPercentilesBucketAggregation.Percents { get; set; }

		public PercentilesBucketAggregationDescriptor Percents(IEnumerable<double> percentages) =>
			Assign(percentages?.ToList(), (a, v) => a.Percents = v);

		public PercentilesBucketAggregationDescriptor Percents(params double[] percentages) =>
			Assign(percentages?.ToList(), (a, v) => a.Percents = v);
	}
}
