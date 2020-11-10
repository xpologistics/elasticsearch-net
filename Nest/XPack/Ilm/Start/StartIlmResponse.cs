namespace Nest6
{
	public interface IStartIlmResponse : IAcknowledgedResponse { }

	public class StartIlmResponse : AcknowledgedResponseBase, IStartIlmResponse { }
}
