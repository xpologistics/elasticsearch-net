using Newtonsoft.Json;

namespace Nest6
{
	public interface IClearScrollResponse : IResponse { }

	[JsonObject]
	public class ClearScrollResponse : ResponseBase, IClearScrollResponse { }
}
