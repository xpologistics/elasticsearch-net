using Newtonsoft.Json;

namespace Nest6
{
	public class AggregationProfile
	{
		/// <summary>
		/// Detailed stats about how the time was spent
		/// </summary>
		[JsonProperty("breakdown")]
		public AggregationBreakdown Breakdown { get; internal set; }

		/// <summary>
		/// The user defined name of the aggregation
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; internal set; }

		/// <summary>
		/// The time this aggregation took, in nanoseconds
		/// </summary>
		[JsonProperty("time_in_nanos")]
		public long TimeInNanoseconds { get; internal set; }

		/// <summary>
		/// The Elasticsearch aggregation type
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; internal set; }
	}
}
