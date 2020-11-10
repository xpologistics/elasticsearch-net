using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class CatAllocationRecord : ICatRecord
	{
		[JsonProperty("diskAvail")]
		public string DiskAvailable { get; set; }

		[JsonProperty("diskRatio")]
		public string DiskRatio { get; set; }

		[JsonProperty("diskUsed")]
		public string DiskUsed { get; set; }

		[JsonProperty("ip")]
		public string Ip { get; set; }

		[JsonProperty("node")]
		public string Node { get; set; }

		[JsonProperty("shards")]
		public string Shards { get; set; }
	}
}
