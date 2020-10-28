using System.Collections.Generic;

namespace Nest6
{
	public interface IIsADictionary { }

	public interface IIsADictionary<TKey, TValue> : IDictionary<TKey, TValue>, IIsADictionary { }
}
