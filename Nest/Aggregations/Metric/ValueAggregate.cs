namespace Nest6
{
	public class ValueAggregate : MetricAggregateBase
	{
		public double? Value { get; set; }

		public string ValueAsString { get; set; }
	}
}
