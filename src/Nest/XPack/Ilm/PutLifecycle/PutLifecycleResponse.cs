namespace Nest6
{
	public interface IPutLifecycleResponse : IAcknowledgedResponse { }

	public class PutLifecycleResponse : AcknowledgedResponseBase, IPutLifecycleResponse { }
}
