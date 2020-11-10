using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class StoreStats
	{
		[JsonProperty("size")]
		public string Size { get; set; }

		[JsonProperty("size_in_bytes")]
		public double SizeInBytes { get; set; }
	}
}
