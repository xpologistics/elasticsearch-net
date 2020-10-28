namespace Nest6
{
	public interface IDeleteJobResponse : IAcknowledgedResponse { }

	public class DeleteJobResponse : AcknowledgedResponseBase, IDeleteJobResponse { }
}
