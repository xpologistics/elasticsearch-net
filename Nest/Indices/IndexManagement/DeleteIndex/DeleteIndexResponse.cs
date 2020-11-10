namespace Nest6
{
	public interface IDeleteIndexResponse : IIndicesResponse { }

	public class DeleteIndexResponse : IndicesResponseBase, IDeleteIndexResponse { }
}
