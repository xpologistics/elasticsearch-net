namespace Nest6
{
	public interface IClearCacheResponse : IShardsOperationResponse { }

	public class ClearCacheResponse : ShardsOperationResponseBase, IClearCacheResponse { }
}
