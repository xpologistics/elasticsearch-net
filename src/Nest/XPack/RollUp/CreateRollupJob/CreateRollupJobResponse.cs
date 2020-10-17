using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface ICreateRollupJobResponse : IAcknowledgedResponse { }

	public class CreateRollupJobResponse : AcknowledgedResponseBase, ICreateRollupJobResponse { }
}
