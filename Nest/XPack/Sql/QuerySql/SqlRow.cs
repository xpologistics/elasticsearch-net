using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nest6
{
	public class SqlRow : ReadOnlyCollection<SqlValue>
	{
		public SqlRow(IList<SqlValue> list) : base(list) { }
	}
}
