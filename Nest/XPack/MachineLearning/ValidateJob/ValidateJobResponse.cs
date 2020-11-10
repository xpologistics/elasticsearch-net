namespace Nest6
{
	public interface IValidateJobResponse : IAcknowledgedResponse { }

	public class ValidateJobResponse : AcknowledgedResponseBase, IValidateJobResponse { }
}
