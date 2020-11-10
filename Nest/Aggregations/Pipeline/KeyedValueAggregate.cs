using System.Collections.Generic;

namespace Nest6
{
	public class KeyedValueAggregate : ValueAggregate
	{
		public IList<string> Keys { get; set; }
	}
}
