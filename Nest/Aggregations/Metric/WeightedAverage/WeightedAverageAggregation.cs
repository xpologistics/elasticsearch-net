﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<WeightedAverageAggregation>))]
	public interface IWeightedAverageAggregation : IAggregation
	{
		/// <summary> The optional numeric response formatter</summary>
		[JsonProperty("format")]
		string Format { get; set; }

		/// <summary> The configuration for the field or script that provides the values</summary>
		[JsonProperty("value")]
		IWeightedAverageValue Value { get; set; }

		/// <summary> A hint about the values for pure scripts or unmapped fields </summary>
		[JsonProperty("value_type")]
		ValueType? ValueType { get; set; }

		/// <summary> The configuration for the field or script that provides the weights</summary>
		[JsonProperty("weight")]
		IWeightedAverageValue Weight { get; set; }
	}

	public class WeightedAverageAggregation : AggregationBase, IWeightedAverageAggregation
	{
		internal WeightedAverageAggregation() { }

		public WeightedAverageAggregation(string name) : base(name) { }

		/// <inheritdoc cref="IWeightedAverageAggregation.Format" />
		public string Format { get; set; }

		/// <inheritdoc cref="IWeightedAverageAggregation.Value" />
		public IWeightedAverageValue Value { get; set; }

		/// <inheritdoc cref="IWeightedAverageAggregation.ValueType" />
		public ValueType? ValueType { get; set; }

		/// <inheritdoc cref="IWeightedAverageAggregation.Weight" />
		public IWeightedAverageValue Weight { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.WeightedAverage = this;
	}

	public class WeightedAverageAggregationDescriptor<T>
		: DescriptorBase<WeightedAverageAggregationDescriptor<T>, IWeightedAverageAggregation>
			, IWeightedAverageAggregation
		where T : class
	{
		string IWeightedAverageAggregation.Format { get; set; }
		IDictionary<string, object> IAggregation.Meta { get; set; }
		string IAggregation.Name { get; set; }
		IWeightedAverageValue IWeightedAverageAggregation.Value { get; set; }
		ValueType? IWeightedAverageAggregation.ValueType { get; set; }
		IWeightedAverageValue IWeightedAverageAggregation.Weight { get; set; }

		/// <inheritdoc cref="IAggregation.Meta" />
		public WeightedAverageAggregationDescriptor<T> Meta(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> selector) =>
			Assign(selector, (a, v) => a.Meta = v?.Invoke(new FluentDictionary<string, object>()));

		/// <inheritdoc cref="IWeightedAverageAggregation.Value" />
		public WeightedAverageAggregationDescriptor<T> Value(Func<WeightedAverageValueDescriptor<T>, IWeightedAverageValue> selector) =>
			Assign(selector, (a, v) => a.Value = v?.Invoke(new WeightedAverageValueDescriptor<T>()));

		/// <inheritdoc cref="IWeightedAverageAggregation.Weight" />
		public WeightedAverageAggregationDescriptor<T> Weight(Func<WeightedAverageValueDescriptor<T>, IWeightedAverageValue> selector) =>
			Assign(selector, (a, v) => a.Weight = v?.Invoke(new WeightedAverageValueDescriptor<T>()));

		/// <inheritdoc cref="IWeightedAverageAggregation.Format" />
		public WeightedAverageAggregationDescriptor<T> Format(string format) => Assign(format, (a, v) => a.Format = v);

		/// <inheritdoc cref="IWeightedAverageAggregation.ValueType" />
		public WeightedAverageAggregationDescriptor<T> ValueType(ValueType? valueType) => Assign(valueType, (a, v) => a.ValueType = v);
	}
}
