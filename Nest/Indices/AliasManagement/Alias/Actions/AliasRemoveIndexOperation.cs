using Newtonsoft.Json;

namespace Nest6
{
	public class AliasRemoveIndexOperation
	{
		[JsonProperty("index")]
		public IndexName Index { get; set; }
	}
}
