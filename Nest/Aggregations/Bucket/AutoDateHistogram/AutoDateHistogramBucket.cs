namespace Nest6
{
	public class AutoDateHistogramAggregate : MultiBucketAggregate<DateHistogramBucket>
	{
		public Time Interval { get; internal set; }
	}
}
