using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class CompactNodeInfo
	{
		[JsonProperty("name")]
		public string Name { get; internal set; }
	}
}
