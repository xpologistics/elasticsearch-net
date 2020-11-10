namespace Nest6
{
	public interface ICloseIndexResponse : IAcknowledgedResponse { }

	public class CloseIndexResponse : AcknowledgedResponseBase, ICloseIndexResponse { }
}
