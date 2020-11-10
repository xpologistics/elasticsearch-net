using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IPauseFollowIndexResponse : IAcknowledgedResponse { }

	public class PauseFollowIndexResponse : AcknowledgedResponseBase, IPauseFollowIndexResponse { }
}
