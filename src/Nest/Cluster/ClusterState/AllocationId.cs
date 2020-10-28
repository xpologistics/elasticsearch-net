using Newtonsoft.Json;

namespace Nest6
{
	public class AllocationId
	{
		[JsonProperty("id")]
		public string Id { get; internal set; }
	}
}
