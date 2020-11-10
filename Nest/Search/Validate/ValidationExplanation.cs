using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ValidationExplanation
	{
		[JsonProperty("error")]
		public string Error { get; internal set; }

		[JsonProperty("explanation")]
		public string Explanation { get; internal set; }

		[JsonProperty("index")]
		public string Index { get; internal set; }

		[JsonProperty("valid")]
		public bool Valid { get; internal set; }
	}
}
