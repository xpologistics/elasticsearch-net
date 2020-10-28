namespace Nest6
{
	public interface IPutPipelineResponse : IAcknowledgedResponse { }

	public class PutPipelineResponse : AcknowledgedResponseBase, IPutPipelineResponse { }
}
