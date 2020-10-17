using Newtonsoft.Json;

namespace Nest6
{
	public interface IPingResponse : IResponse { }

	[JsonObject]
	public class PingResponse : ResponseBase, IPingResponse { }
}
