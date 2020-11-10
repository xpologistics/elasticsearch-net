using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// The Allocate action allows you to specify which nodes are allowed to host the shards of the index and set the number of
	/// replicas. Behind the scenes, it is modifying the index settings for shard filtering and/or replica counts. When
	/// updating the number of replicas, configuring allocation rules is optional. When configuring allocation rules, setting
	/// number of replicas is optional. Although this action can be treated as two separate index settings updates, both can be
	/// configured at once.
	/// </summary>
	public interface IAllocateLifecycleAction : ILifecycleAction
	{
		/// <summary>
		/// Assigns an index to nodes having none of the attributes
		/// </summary>
		[JsonProperty("exclude")]
		IDictionary<string, string> Exclude { get; set; }

		/// <summary>
		/// Assigns an index to nodes having at least one of the attributes
		/// </summary>
		[JsonProperty("include")]
		IDictionary<string, string> Include { get; set; }

		/// <summary>
		/// The number of replicas to assign to the index
		/// </summary>
		[JsonProperty("number_of_replicas")]
		int? NumberOfReplicas { get; set; }

		/// <summary>
		/// Assigns an index to nodes having all of the attributes
		/// </summary>
		[JsonProperty("require")]
		IDictionary<string, string> Require { get; set; }
	}

	public class AllocateLifecycleAction : IAllocateLifecycleAction
	{
		/// <inheritdoc />
		public IDictionary<string, string> Exclude { get; set; }

		/// <inheritdoc />
		public IDictionary<string, string> Include { get; set; }

		/// <inheritdoc />
		public int? NumberOfReplicas { get; set; }

		/// <inheritdoc />
		public IDictionary<string, string> Require { get; set; }
	}

	public class AllocateLifecycleActionDescriptor
		: DescriptorBase<AllocateLifecycleActionDescriptor, IAllocateLifecycleAction>, IAllocateLifecycleAction
	{
		/// <inheritdoc cref="IAllocateLifecycleAction.Exclude"/>
		IDictionary<string, string> IAllocateLifecycleAction.Exclude { get; set; }

		/// <inheritdoc cref="IAllocateLifecycleAction.Include"/>
		IDictionary<string, string> IAllocateLifecycleAction.Include { get; set; }

		/// <inheritdoc cref="IAllocateLifecycleAction.NumberOfReplicas"/>
		int? IAllocateLifecycleAction.NumberOfReplicas { get; set; }

		/// <inheritdoc cref="IAllocateLifecycleAction.Require"/>
		IDictionary<string, string> IAllocateLifecycleAction.Require { get; set; }

		/// <inheritdoc cref="IAllocateLifecycleAction.NumberOfReplicas"/>
		public AllocateLifecycleActionDescriptor NumberOfReplicas(int? numberOfReplicas)
			=> Assign(numberOfReplicas, (a, v) => a.NumberOfReplicas = numberOfReplicas);

		/// <inheritdoc cref="IAllocateLifecycleAction.Include"/>
		public AllocateLifecycleActionDescriptor Include(Func<FluentDictionary<string, string>, FluentDictionary<string, string>> includeSelector) =>
			Assign(includeSelector(new FluentDictionary<string, string>()), (a, v) => a.Include = v);

		/// <inheritdoc cref="IAllocateLifecycleAction.Exclude"/>
		public AllocateLifecycleActionDescriptor Exclude(Func<FluentDictionary<string, string>, FluentDictionary<string, string>> excludeSelector) =>
			Assign(excludeSelector(new FluentDictionary<string, string>()), (a, v) => a.Exclude = v);

		/// <inheritdoc cref="IAllocateLifecycleAction.Require"/>
		public AllocateLifecycleActionDescriptor Require(Func<FluentDictionary<string, string>, FluentDictionary<string, string>> requireSelector) =>
			Assign(requireSelector(new FluentDictionary<string, string>()), (a, v) => a.Require = v);
	}
}
