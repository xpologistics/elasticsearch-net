namespace Nest6
{
	public interface IRefreshResponse : IShardsOperationResponse { }

	public class RefreshResponse : ShardsOperationResponseBase, IRefreshResponse { }
}
