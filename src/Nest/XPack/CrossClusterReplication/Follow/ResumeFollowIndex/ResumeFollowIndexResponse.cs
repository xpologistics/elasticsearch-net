using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IResumeFollowIndexResponse : IAcknowledgedResponse { }

	public class ResumeFollowIndexResponse : AcknowledgedResponseBase, IResumeFollowIndexResponse { }
}
