namespace Nest6
{
	public interface IDeletePipelineResponse : IAcknowledgedResponse { }

	public class DeletePipelineResponse : AcknowledgedResponseBase, IDeletePipelineResponse { }
}
