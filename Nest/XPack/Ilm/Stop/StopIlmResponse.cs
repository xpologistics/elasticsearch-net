namespace Nest6
{
	public interface IStopIlmResponse : IAcknowledgedResponse { }

	public class StopIlmResponse : AcknowledgedResponseBase, IStopIlmResponse { }
}
