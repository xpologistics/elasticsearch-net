namespace Nest6
{
	public interface IPutScriptResponse : IAcknowledgedResponse { }

	public class PutScriptResponse : AcknowledgedResponseBase, IPutScriptResponse { }
}
