namespace Nest6
{
	public interface IMoveToStepResponse : IAcknowledgedResponse { }

	public class MoveToStepResponse : AcknowledgedResponseBase, IMoveToStepResponse { }
}
