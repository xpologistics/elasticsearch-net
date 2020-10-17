namespace Nest6
{
	public interface IDeleteForecastResponse : IAcknowledgedResponse { }

	public class DeleteForecastResponse : AcknowledgedResponseBase, IDeleteForecastResponse { }
}
