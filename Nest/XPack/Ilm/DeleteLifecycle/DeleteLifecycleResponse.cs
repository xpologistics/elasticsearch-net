namespace Nest6
{
	public interface IDeleteLifecycleResponse : IAcknowledgedResponse
	{
	}

	public class DeleteLifecycleResponse : AcknowledgedResponseBase, IDeleteLifecycleResponse
	{
	}
}
