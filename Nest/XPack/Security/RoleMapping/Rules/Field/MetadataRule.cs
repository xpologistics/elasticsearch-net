using System;

namespace Nest6
{
	public class MetadataRule : FieldRuleBase
	{
		public MetadataRule(string key, object value) => Metadata = Tuple.Create(key, value);
	}
}
