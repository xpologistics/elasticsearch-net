using Newtonsoft.Json;

namespace Nest6
{
	public class SampleDiversity
	{
		[JsonProperty("field")]
		public Field Field { get; set; }

		[JsonProperty("max_docs_per_value")]
		public int? MaxDocumentsPerValue { get; set; }
	}
}
