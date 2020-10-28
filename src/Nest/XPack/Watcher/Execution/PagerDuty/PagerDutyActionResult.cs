using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class PagerDutyActionResult
	{
		[JsonProperty("sent_event")]
		public PagerDutyActionEventResult SentEvent { get; set; }
	}
}
