using Newtonsoft.Json;

namespace Nest6
{
	public interface IFlushJobResponse : IResponse
	{
		[JsonProperty("flushed")]
		bool Flushed { get; }
	}

	public class FlushJobResponse : ResponseBase, IFlushJobResponse
	{
		public bool Flushed { get; internal set; }
	}
}
