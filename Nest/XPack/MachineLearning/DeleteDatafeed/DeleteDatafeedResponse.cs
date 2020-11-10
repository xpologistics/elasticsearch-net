namespace Nest6
{
	public interface IDeleteDatafeedResponse : IAcknowledgedResponse { }

	public class DeleteDatafeedResponse : AcknowledgedResponseBase, IDeleteDatafeedResponse { }
}
