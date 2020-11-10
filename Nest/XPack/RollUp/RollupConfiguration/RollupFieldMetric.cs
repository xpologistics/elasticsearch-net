﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<RollupFieldMetric>))]
	public interface IRollupFieldMetric
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("metrics")]
		IEnumerable<RollupMetric> Metrics { get; set; }
	}

	public class RollupFieldMetric : IRollupFieldMetric
	{
		public Field Field { get; set; }
		public IEnumerable<RollupMetric> Metrics { get; set; }
	}

	public class RollupFieldMetricsDescriptor<T> : DescriptorPromiseBase<RollupFieldMetricsDescriptor<T>, IList<IRollupFieldMetric>>
		where T : class
	{
		public RollupFieldMetricsDescriptor() : base(new List<IRollupFieldMetric>()) { }

		public RollupFieldMetricsDescriptor<T> Field(Expression<Func<T, object>> field, params RollupMetric[] metrics) =>
			Assign(new RollupFieldMetric { Field = field, Metrics = metrics }, (a, v) => a.Add(v));

		public RollupFieldMetricsDescriptor<T> Field(Field field, params RollupMetric[] metrics) =>
			Assign(new RollupFieldMetric { Field = field, Metrics = metrics }, (a, v) => a.Add(v));

		public RollupFieldMetricsDescriptor<T> Field(Expression<Func<T, object>> field, IEnumerable<RollupMetric> metrics) =>
			Assign(new RollupFieldMetric { Field = field, Metrics = metrics }, (a, v) => a.Add(v));

		public RollupFieldMetricsDescriptor<T> Field(Field field, IEnumerable<RollupMetric> metrics) =>
			Assign(new RollupFieldMetric { Field = field, Metrics = metrics }, (a, v) => a.Add(v));
	}
}
