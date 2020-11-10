using System.Collections.Generic;

namespace Nest6
{
	public abstract class MatrixAggregateBase : IAggregate
	{
		public IReadOnlyDictionary<string, object> Meta { get; set; } = EmptyReadOnly<string, object>.Dictionary;
	}
}
