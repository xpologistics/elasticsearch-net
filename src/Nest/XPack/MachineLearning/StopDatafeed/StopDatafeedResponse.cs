using Newtonsoft.Json;

namespace Nest6
{
	public interface IStopDatafeedResponse : IResponse
	{
		bool Stopped { get; }
	}

	public class StopDatafeedResponse : ResponseBase, IStopDatafeedResponse
	{
		[JsonProperty("stopped")]
		public bool Stopped { get; internal set; }
	}
}
