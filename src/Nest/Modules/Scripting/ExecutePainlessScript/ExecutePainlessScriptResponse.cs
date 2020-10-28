using Newtonsoft.Json;

namespace Nest6
{
	public interface IExecutePainlessScriptResponse<TResult> : IResponse
	{
		[JsonProperty("result")]
		TResult Result { get; }
	}

	public class ExecutePainlessScriptResponse<TResult> : ResponseBase, IExecutePainlessScriptResponse<TResult>
	{
		public TResult Result { get; set; }
	}
}
