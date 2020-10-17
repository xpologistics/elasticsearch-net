namespace Nest6
{
	public interface IRetryIlmResponse : IAcknowledgedResponse { }

	public class RetryIlmResponse : AcknowledgedResponseBase, IRetryIlmResponse { }
}
