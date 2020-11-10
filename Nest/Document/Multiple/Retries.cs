using Newtonsoft.Json;

namespace Nest6
{
	public class Retries
	{
		[JsonProperty("bulk")]
		public long Bulk { get; internal set; }

		[JsonProperty("search")]
		public long Search { get; internal set; }
	}
}
