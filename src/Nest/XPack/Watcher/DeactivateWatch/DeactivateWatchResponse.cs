using Newtonsoft.Json;

namespace Nest6
{
	public interface IDeactivateWatchResponse : IResponse
	{
		[JsonProperty("status")]
		ActivationStatus Status { get; }
	}

	public class DeactivateWatchResponse : ResponseBase, IDeactivateWatchResponse
	{
		[JsonProperty("status")]
		public ActivationStatus Status { get; internal set; }
	}
}
