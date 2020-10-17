using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, HighlightHit>))]
	public class HighlightFieldDictionary : Dictionary<string, HighlightHit>
	{
		public HighlightFieldDictionary(IDictionary<string, HighlightHit> dictionary = null)
		{
			if (dictionary == null) return;

			foreach (var kv in dictionary) Add(kv.Key, kv.Value);
		}
	}
}
