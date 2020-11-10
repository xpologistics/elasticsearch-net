using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A value source that can be applied on numeric values to build fixed size interval over the values.
	/// The interval parameter defines how the numeric values should be transformed.
	/// For instance an interval set to 5 will translate any numeric values to its closest interval,
	/// a value of 101 would be translated to 100 which is the key for the interval between 100 and 105.
	/// </summary>
	public interface IHistogramCompositeAggregationSource : ICompositeAggregationSource
	{
		/// <summary>
		/// The interval to use when bucketing documents
		/// </summary>
		[JsonProperty("interval")]
		double? Interval { get; set; }

		/// <summary>
		/// A script to create the values for the composite buckets
		/// </summary>
		[JsonProperty("script")]
		IScript Script { get; set; }
	}

	/// <inheritdoc cref="IHistogramCompositeAggregationSource" />
	public class HistogramCompositeAggregationSource : CompositeAggregationSourceBase, IHistogramCompositeAggregationSource
	{
		public HistogramCompositeAggregationSource(string name) : base(name) { }

		/// <inheritdoc />
		public double? Interval { get; set; }

		/// <inheritdoc />
		public IScript Script { get; set; }

		/// <inheritdoc />
		protected override string SourceType => "histogram";
	}

	/// <inheritdoc cref="IHistogramCompositeAggregationSource" />
	public class HistogramCompositeAggregationSourceDescriptor<T>
		: CompositeAggregationSourceDescriptorBase<HistogramCompositeAggregationSourceDescriptor<T>, IHistogramCompositeAggregationSource, T>,
			IHistogramCompositeAggregationSource
	{
		public HistogramCompositeAggregationSourceDescriptor(string name) : base(name, "histogram") { }

		double? IHistogramCompositeAggregationSource.Interval { get; set; }
		IScript IHistogramCompositeAggregationSource.Script { get; set; }

		/// <inheritdoc cref="IHistogramCompositeAggregationSource.Interval" />
		public HistogramCompositeAggregationSourceDescriptor<T> Interval(double? interval) =>
			Assign(interval, (a, v) => a.Interval = v);

		/// <inheritdoc cref="IHistogramCompositeAggregationSource.Script" />
		public HistogramCompositeAggregationSourceDescriptor<T> Script(Func<ScriptDescriptor, IScript> selector) =>
			Assign(selector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));
	}
}
