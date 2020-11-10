namespace Nest6
{
	public interface IPutMappingResponse : IIndicesResponse { }

	public class PutMappingResponse : IndicesResponseBase, IPutMappingResponse { }
}
