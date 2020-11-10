using Newtonsoft.Json;

namespace Nest6
{
	public interface ICloseJobResponse : IResponse
	{
		[JsonProperty("closed")]
		bool Closed { get; }
	}

	public class CloseJobResponse : ResponseBase, ICloseJobResponse
	{
		public bool Closed { get; internal set; }
	}
}
