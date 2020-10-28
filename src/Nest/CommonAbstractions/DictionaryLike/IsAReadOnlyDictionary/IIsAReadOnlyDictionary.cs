using System.Collections.Generic;

namespace Nest6
{
	public interface IIsAReadOnlyDictionary { }

	public interface IIsAReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IIsAReadOnlyDictionary { }
}
