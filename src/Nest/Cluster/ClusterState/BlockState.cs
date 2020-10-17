using Newtonsoft.Json;

namespace Nest6
{
	public class BlockState
	{
		[JsonProperty("read_only")]
		public bool ReadOnly { get; set; }
	}
}
