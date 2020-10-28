using Newtonsoft.Json;

namespace Nest6
{
	public interface IGetIlmStatusResponse : IResponse
	{
		[JsonProperty("operation_mode")]
		LifecycleOperationMode OperationMode { get; }
	}

	public class GetIlmStatusResponse : ResponseBase, IGetIlmStatusResponse
	{
		public LifecycleOperationMode OperationMode { get; internal set; }
	}
}
