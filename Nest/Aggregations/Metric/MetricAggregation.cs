﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IMetricAggregation : IAggregation
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("missing")]
		double? Missing { get; set; }

		[JsonProperty("script")]
		IScript Script { get; set; }
	}

	public abstract class MetricAggregationBase : AggregationBase, IMetricAggregation
	{
		internal MetricAggregationBase() { }

		protected MetricAggregationBase(string name, Field field) : base(name) => Field = field;

		public Field Field { get; set; }
		public double? Missing { get; set; }
		public virtual IScript Script { get; set; }
	}

	public abstract class MetricAggregationDescriptorBase<TMetricAggregation, TMetricAggregationInterface, T>
		: DescriptorBase<TMetricAggregation, TMetricAggregationInterface>, IMetricAggregation
		where TMetricAggregation : MetricAggregationDescriptorBase<TMetricAggregation, TMetricAggregationInterface, T>
		, TMetricAggregationInterface, IMetricAggregation
		where T : class
		where TMetricAggregationInterface : class, IMetricAggregation
	{
		Field IMetricAggregation.Field { get; set; }

		IDictionary<string, object> IAggregation.Meta { get; set; }

		double? IMetricAggregation.Missing { get; set; }

		string IAggregation.Name { get; set; }

		IScript IMetricAggregation.Script { get; set; }

		public TMetricAggregation Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public TMetricAggregation Field(Expression<Func<T, object>> field) => Assign(field, (a, v) => a.Field = v);

		public virtual TMetricAggregation Script(string script) => Assign((InlineScript)script, (a, v) => a.Script = v);

		public virtual TMetricAggregation Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(scriptSelector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));

		public TMetricAggregation Missing(double? missing) => Assign(missing, (a, v) => a.Missing = v);

		public TMetricAggregation Meta(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> selector) =>
			Assign(selector, (a, v) => a.Meta = v?.Invoke(new FluentDictionary<string, object>()));
	}
}
