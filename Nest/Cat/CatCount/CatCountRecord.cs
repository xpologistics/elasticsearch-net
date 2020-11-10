using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class CatCountRecord : ICatRecord
	{
		[JsonProperty("count")]
		public string Count { get; set; }

		[JsonProperty("epoch")]
		public string Epoch { get; set; }

		[JsonProperty("timestamp")]
		public string Timestamp { get; set; }
	}
}
