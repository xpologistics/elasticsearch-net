namespace Nest6
{
	public interface IFlushResponse : IShardsOperationResponse { }

	public class FlushResponse : ShardsOperationResponseBase, IFlushResponse { }
}
