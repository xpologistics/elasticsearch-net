using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<HistogramAggregation>))]
	public interface IHistogramAggregation : IBucketAggregation
	{
		[JsonProperty("extended_bounds")]
		ExtendedBounds<double> ExtendedBounds { get; set; }

		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("interval")]
		double? Interval { get; set; }

		[JsonProperty("min_doc_count")]
		int? MinimumDocumentCount { get; set; }

		[JsonProperty("missing")]
		double? Missing { get; set; }

		[JsonProperty("offset")]
		double? Offset { get; set; }

		[JsonProperty("order")]
		HistogramOrder Order { get; set; }

		[JsonProperty("script")]
		IScript Script { get; set; }
	}

	public class HistogramAggregation : BucketAggregationBase, IHistogramAggregation
	{
		internal HistogramAggregation() { }

		public HistogramAggregation(string name) : base(name) { }

		public ExtendedBounds<double> ExtendedBounds { get; set; }
		public Field Field { get; set; }
		public double? Interval { get; set; }
		public int? MinimumDocumentCount { get; set; }
		public double? Missing { get; set; }
		public double? Offset { get; set; }
		public HistogramOrder Order { get; set; }
		public IScript Script { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Histogram = this;
	}

	public class HistogramAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<HistogramAggregationDescriptor<T>, IHistogramAggregation, T>, IHistogramAggregation
		where T : class
	{
		ExtendedBounds<double> IHistogramAggregation.ExtendedBounds { get; set; }
		Field IHistogramAggregation.Field { get; set; }

		double? IHistogramAggregation.Interval { get; set; }

		int? IHistogramAggregation.MinimumDocumentCount { get; set; }

		double? IHistogramAggregation.Missing { get; set; }

		double? IHistogramAggregation.Offset { get; set; }

		HistogramOrder IHistogramAggregation.Order { get; set; }

		IScript IHistogramAggregation.Script { get; set; }

		public HistogramAggregationDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public HistogramAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(field, (a, v) => a.Field = v);

		public HistogramAggregationDescriptor<T> Script(string script) => Assign((InlineScript)script, (a, v) => a.Script = v);

		public HistogramAggregationDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(scriptSelector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));

		public HistogramAggregationDescriptor<T> Interval(double? interval) => Assign(interval, (a, v) => a.Interval = v);

		public HistogramAggregationDescriptor<T> MinimumDocumentCount(int? minimumDocumentCount) =>
			Assign(minimumDocumentCount, (a, v) => a.MinimumDocumentCount = v);

		public HistogramAggregationDescriptor<T> Order(HistogramOrder order) => Assign(order, (a, v) => a.Order = v);

		public HistogramAggregationDescriptor<T> OrderAscending(string key) =>
			Assign(new HistogramOrder { Key = key, Order = SortOrder.Descending }, (a, v) => a.Order = v);

		public HistogramAggregationDescriptor<T> OrderDescending(string key) =>
			Assign(new HistogramOrder { Key = key, Order = SortOrder.Descending }, (a, v) => a.Order = v);

		public HistogramAggregationDescriptor<T> ExtendedBounds(double min, double max) =>
			Assign(new ExtendedBounds<double> { Minimum = min, Maximum = max }, (a, v) => a.ExtendedBounds = v);

		public HistogramAggregationDescriptor<T> Offset(double? offset) => Assign(offset, (a, v) => a.Offset = v);

		public HistogramAggregationDescriptor<T> Missing(double? missing) => Assign(missing, (a, v) => a.Missing = v);
	}
}
