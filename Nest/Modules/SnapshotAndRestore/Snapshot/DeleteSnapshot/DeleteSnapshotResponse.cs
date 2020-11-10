namespace Nest6
{
	public interface IDeleteSnapshotResponse : IAcknowledgedResponse { }

	public class DeleteSnapshotResponse : AcknowledgedResponseBase, IDeleteSnapshotResponse { }
}
