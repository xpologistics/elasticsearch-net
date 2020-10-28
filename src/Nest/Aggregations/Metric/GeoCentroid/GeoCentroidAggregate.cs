using Newtonsoft.Json;

namespace Nest6
{
	public class GeoCentroidAggregate : MetricAggregateBase
	{
		[JsonProperty("count")]
		public long Count { get; set; }

		[JsonProperty("location")]
		public GeoLocation Location { get; set; }
	}
}
