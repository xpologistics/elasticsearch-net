using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface IRestartWatcherResponse : IAcknowledgedResponse { }

	public class RestartWatcherResponse : AcknowledgedResponseBase, IRestartWatcherResponse { }
}
