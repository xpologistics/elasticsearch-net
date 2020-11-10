using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A multi-bucket aggregation that creates composite buckets from different sources.
	/// </summary>
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<CompositeAggregation>))]
	public interface ICompositeAggregation : IBucketAggregation
	{
		/// <summary>
		/// Used to retrieve the composite buckets that are after the
		/// last composite buckets returned in a previous round
		/// </summary>
		[JsonProperty("after")]
		object After { get; set; }

		/// <summary>
		/// Defines how many composite buckets should be returned.
		/// Each composite bucket is considered as a single bucket so
		/// setting a size of 10 will return the first 10 composite buckets
		/// created from the values source.
		/// </summary>
		[JsonProperty("size")]
		int? Size { get; set; }

		/// <summary>
		/// Controls the sources that should be used to build the composite buckets
		/// </summary>
		[JsonProperty("sources")]
		IEnumerable<ICompositeAggregationSource> Sources { get; set; }
	}

	/// <inheritdoc cref="ICompositeAggregation" />
	public class CompositeAggregation : BucketAggregationBase, ICompositeAggregation
	{
		internal CompositeAggregation() { }

		public CompositeAggregation(string name) : base(name) { }

		/// <inheritdoc />
		public object After { get; set; }

		/// <inheritdoc />
		public int? Size { get; set; }

		/// <inheritdoc />
		public IEnumerable<ICompositeAggregationSource> Sources { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Composite = this;
	}

	/// <inheritdoc cref="ICompositeAggregation" />
	public class CompositeAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<CompositeAggregationDescriptor<T>, ICompositeAggregation, T>
			, ICompositeAggregation
		where T : class
	{
		object ICompositeAggregation.After { get; set; }
		int? ICompositeAggregation.Size { get; set; }
		IEnumerable<ICompositeAggregationSource> ICompositeAggregation.Sources { get; set; }

		/// <inheritdoc cref="ICompositeAggregation.Sources" />
		public CompositeAggregationDescriptor<T> Sources(
			Func<CompositeAggregationSourcesDescriptor<T>, IPromise<IList<ICompositeAggregationSource>>> selector
		) =>
			Assign(selector, (a, v) => a.Sources = v?.Invoke(new CompositeAggregationSourcesDescriptor<T>())?.Value);

		/// <inheritdoc cref="ICompositeAggregation.Size" />
		public CompositeAggregationDescriptor<T> Size(int? size) => Assign(size, (a, v) => a.Size = v);

		/// <inheritdoc cref="ICompositeAggregation.After" />
		public CompositeAggregationDescriptor<T> After(object after) => Assign(after, (a, v) => a.After = v);
	}
}
