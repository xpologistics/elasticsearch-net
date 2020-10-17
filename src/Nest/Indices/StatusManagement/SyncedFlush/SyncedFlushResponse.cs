namespace Nest6
{
	public interface ISyncedFlushResponse : IShardsOperationResponse { }

	public class SyncedFlushResponse : ShardsOperationResponseBase, ISyncedFlushResponse { }
}
