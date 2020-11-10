using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// The Rollover Action rolls an alias over to a new index when the existing index meets one of the rollover conditions.
	/// </summary>
	/// <remarks>
	/// Phases allowed: hot.
	/// </remarks>
	public interface IRolloverLifecycleAction : ILifecycleAction
	{
		/// <summary>
		/// Max time elapsed from index creation.
		/// </summary>
		[JsonProperty("max_age")]
		Time MaximumAge { get; set; }

		/// <summary>
		/// Max number of documents an index is to contain before rolling over.
		/// </summary>
		[JsonProperty("max_docs")]
		long? MaximumDocuments { get; set; }

		/// <summary>
		/// Max primary shard index storage size in bytes.
		/// </summary>
		[JsonProperty("max_size")]
		long? MaximumSize { get; set; }
	}

	public class RolloverLifecycleAction : IRolloverLifecycleAction
	{
		/// <inheritdoc />
		public Time MaximumAge { get; set; }

		/// <inheritdoc />
		public long? MaximumDocuments { get; set; }

		/// <inheritdoc />
		public long? MaximumSize { get; set; }
	}

	public class RolloverLifecycleActionDescriptor
		: DescriptorBase<RolloverLifecycleActionDescriptor, IRolloverLifecycleAction>, IRolloverLifecycleAction
	{
		/// <inheritdoc cref="IRolloverLifecycleAction.MaximumAge" />
		Time IRolloverLifecycleAction.MaximumAge { get; set; }

		/// <inheritdoc cref="IRolloverLifecycleAction.MaximumDocuments" />
		long? IRolloverLifecycleAction.MaximumDocuments { get; set; }

		/// <inheritdoc cref="IRolloverLifecycleAction.MaximumSize" />
		long? IRolloverLifecycleAction.MaximumSize { get; set; }

		/// <inheritdoc cref="IRolloverLifecycleAction.MaximumSize" />
		public RolloverLifecycleActionDescriptor MaximumSize(long? maximumSize) => Assign(maximumSize, (a, v) => a.MaximumSize = maximumSize);

		/// <inheritdoc cref="IRolloverLifecycleAction.MaximumAge" />
		public RolloverLifecycleActionDescriptor MaximumAge(Time maximumAge) => Assign(maximumAge, (a, v) => a.MaximumAge = maximumAge);

		/// <inheritdoc cref="IRolloverLifecycleAction.MaximumDocuments" />
		public RolloverLifecycleActionDescriptor MaximumDocuments(long? maximumDocuments)
			=> Assign(maximumDocuments, (a, v) => a.MaximumDocuments = maximumDocuments);
	}
}
