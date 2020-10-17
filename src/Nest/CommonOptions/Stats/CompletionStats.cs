using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class CompletionStats
	{
		[JsonProperty("size")]
		public string Size { get; set; }

		[JsonProperty("size_in_bytes")]
		public long SizeInBytes { get; set; }
	}
}
