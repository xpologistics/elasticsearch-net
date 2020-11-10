using Newtonsoft.Json;

namespace Nest6
{
	public class ExtendedBounds<T>
	{
		[JsonProperty("max")]
		public T Maximum { get; set; }

		[JsonProperty("min")]
		public T Minimum { get; set; }
	}
}
