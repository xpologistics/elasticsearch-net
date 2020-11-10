namespace Nest6
{
	public interface IDeleteFilterResponse : IAcknowledgedResponse { }

	public class DeleteFilterResponse : AcknowledgedResponseBase, IDeleteFilterResponse { }
}
