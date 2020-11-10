﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Range that defines a bucket for either the <see cref="RangeAggregation" /> or
	/// <see cref="GeoDistanceAggregation" />. If you are looking to store ranges as
	/// part of your document please use explicit range class e.g DateRange, FloatRange etc
	/// </summary>
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<AggregationRange>))]
	public interface IAggregationRange
	{
		[JsonProperty("from")]
		double? From { get; set; }

		[JsonProperty("key")]
		string Key { get; set; }

		[JsonProperty("to")]
		double? To { get; set; }
	}

	/// <inheritdoc />
	public class AggregationRange : IAggregationRange
	{
		public double? From { get; set; }
		public string Key { get; set; }
		public double? To { get; set; }
	}

	/// <inheritdoc />
	public class AggregationRangeDescriptor : DescriptorBase<AggregationRangeDescriptor, IAggregationRange>, IAggregationRange
	{
		double? IAggregationRange.From { get; set; }
		string IAggregationRange.Key { get; set; }
		double? IAggregationRange.To { get; set; }

		public AggregationRangeDescriptor Key(string key) => Assign(key, (a, v) => a.Key = v);

		public AggregationRangeDescriptor From(double? from) => Assign(from, (a, v) => a.From = v);

		public AggregationRangeDescriptor To(double? to) => Assign(to, (a, v) => a.To = v);
	}
}
