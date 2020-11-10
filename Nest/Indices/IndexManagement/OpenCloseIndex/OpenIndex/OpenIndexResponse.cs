namespace Nest6
{
	public interface IOpenIndexResponse : IAcknowledgedResponse { }

	public class OpenIndexResponse : AcknowledgedResponseBase, IOpenIndexResponse { }
}
