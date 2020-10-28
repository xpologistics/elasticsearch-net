using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface IStartWatcherResponse : IAcknowledgedResponse { }

	public class StartWatcherResponse : AcknowledgedResponseBase, IStartWatcherResponse { }
}
