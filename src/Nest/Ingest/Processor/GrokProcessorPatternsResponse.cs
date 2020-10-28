using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IGrokProcessorPatternsResponse : IResponse
	{
		IReadOnlyDictionary<string, string> Patterns { get; }
	}

	public class GrokProcessorPatternsResponse : ResponseBase, IGrokProcessorPatternsResponse
	{
		[JsonProperty("patterns")]
		public IReadOnlyDictionary<string, string> Patterns { get; internal set; } = EmptyReadOnly<string, string>.Dictionary;
	}
}
