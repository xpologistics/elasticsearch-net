namespace Nest6
{
	public interface IUnfollowIndexResponse : IAcknowledgedResponse { }

	public class UnfollowIndexResponse : AcknowledgedResponseBase, IUnfollowIndexResponse { }
}
