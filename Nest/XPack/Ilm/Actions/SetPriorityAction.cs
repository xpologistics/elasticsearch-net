using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// This action sets the index priority on the index as soon as the policy enters the hot, warm, or cold phase. Indices
	/// with a higher priority will be recovered before indices with lower priorities following a node restart. Generally,
	/// indexes in the hot phase should have the highest value and indexes in the cold phase should have the lowest values. For
	/// example: 100 for the hot phase, 50 for the warm phase, and 0 for the cold phase. Indicies that don’t set this value
	/// have an implicit default priority of 1.
	/// </summary>
	/// <remarks>
	/// Phases allowed: hot, warm, cold.
	/// </remarks>
	public interface ISetPriorityLifecycleAction : ILifecycleAction
	{
		/// <summary>
		/// The priority for the index. Must be 0 or greater. The value may also be set to null to remove the priority.
		/// </summary>
		[JsonProperty("priority")]
		int? Priority { get; set; }
	}

	public class SetPriorityLifecycleAction : ISetPriorityLifecycleAction
	{
		/// <inheritdoc />
		public int? Priority { get; set; }
	}

	public class SetPriorityLifecycleActionDescriptor
		: DescriptorBase<SetPriorityLifecycleActionDescriptor, ISetPriorityLifecycleAction>, ISetPriorityLifecycleAction
	{
		/// <inheritdoc cref="ISetPriorityLifecycleAction.Priority"/>
		int? ISetPriorityLifecycleAction.Priority { get; set; }

		/// <inheritdoc cref="ISetPriorityLifecycleAction.Priority"/>
		public SetPriorityLifecycleActionDescriptor Priority(int? priority) => Assign(priority, (a, v) => a.Priority = priority);
	}
}
