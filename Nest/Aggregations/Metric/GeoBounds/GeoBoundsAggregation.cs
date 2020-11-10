﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<GeoBoundsAggregation>))]
	public interface IGeoBoundsAggregation : IMetricAggregation
	{
		[JsonProperty("wrap_longitude")]
		bool? WrapLongitude { get; set; }
	}

	public class GeoBoundsAggregation : MetricAggregationBase, IGeoBoundsAggregation
	{
		internal GeoBoundsAggregation() { }

		public GeoBoundsAggregation(string name, Field field) : base(name, field) { }

		public bool? WrapLongitude { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.GeoBounds = this;
	}

	public class GeoBoundsAggregationDescriptor<T>
		: MetricAggregationDescriptorBase<GeoBoundsAggregationDescriptor<T>, IGeoBoundsAggregation, T>
			, IGeoBoundsAggregation
		where T : class
	{
		bool? IGeoBoundsAggregation.WrapLongitude { get; set; }

		public GeoBoundsAggregationDescriptor<T> WrapLongitude(bool? wrapLongitude = true) =>
			Assign(wrapLongitude, (a, v) => a.WrapLongitude = v);
	}
}
