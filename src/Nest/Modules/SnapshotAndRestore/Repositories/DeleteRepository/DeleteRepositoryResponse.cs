namespace Nest6
{
	public interface IDeleteRepositoryResponse : IAcknowledgedResponse { }

	public class DeleteRepositoryResponse : AcknowledgedResponseBase, IDeleteRepositoryResponse { }
}
