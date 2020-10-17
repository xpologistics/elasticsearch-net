using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface IStartRollupJobResponse : IResponse
	{
		[JsonProperty("started")]
		bool Started { get; set; }
	}

	public class StartRollupJobResponse : ResponseBase, IStartRollupJobResponse
	{
		public bool Started { get; set; }
	}
}
