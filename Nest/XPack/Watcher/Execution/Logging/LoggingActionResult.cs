using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class LoggingActionResult
	{
		[JsonProperty("logged_text")]
		public string LoggedText { get; set; }
	}
}
