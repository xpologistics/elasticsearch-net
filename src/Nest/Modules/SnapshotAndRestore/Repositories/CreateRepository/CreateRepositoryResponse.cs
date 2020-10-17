namespace Nest6
{
	public interface ICreateRepositoryResponse : IAcknowledgedResponse { }

	public class CreateRepositoryResponse : AcknowledgedResponseBase, ICreateRepositoryResponse { }
}
