using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ClusterRerouteExplanation
	{
		[JsonProperty("command")]
		public string Command { get; set; }

		[JsonProperty("decisions")]
		public IEnumerable<ClusterRerouteDecision> Decisions { get; set; }

		[JsonProperty("parameters")]
		public ClusterRerouteParameters Parameters { get; set; }
	}
}
