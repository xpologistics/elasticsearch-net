namespace Nest6
{
	public interface IValidateDetectorResponse : IAcknowledgedResponse { }

	public class ValidateDetectorResponse : AcknowledgedResponseBase, IValidateDetectorResponse { }
}
