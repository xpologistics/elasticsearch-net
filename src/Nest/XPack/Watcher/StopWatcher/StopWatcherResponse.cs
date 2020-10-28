using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface IStopWatcherResponse : IAcknowledgedResponse { }

	public class StopWatcherResponse : AcknowledgedResponseBase, IStopWatcherResponse { }
}
