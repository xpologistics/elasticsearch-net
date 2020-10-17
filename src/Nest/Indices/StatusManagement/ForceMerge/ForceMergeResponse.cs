namespace Nest6
{
	public interface IForceMergeResponse : IShardsOperationResponse { }

	public class ForceMergeResponse : ShardsOperationResponseBase, IForceMergeResponse { }
}
