﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<FuzzySuggester>))]
	public interface IFuzzySuggester
	{
		[JsonProperty("fuzziness")]
		IFuzziness Fuzziness { get; set; }

		[JsonProperty("min_length")]
		int? MinLength { get; set; }

		[JsonProperty("prefix_length")]
		int? PrefixLength { get; set; }

		[JsonProperty("transpositions")]
		bool? Transpositions { get; set; }

		[JsonProperty("unicode_aware")]
		bool? UnicodeAware { get; set; }
	}

	public class FuzzySuggester : IFuzzySuggester
	{
		public IFuzziness Fuzziness { get; set; }
		public int? MinLength { get; set; }
		public int? PrefixLength { get; set; }
		public bool? Transpositions { get; set; }
		public bool? UnicodeAware { get; set; }
	}

	public class FuzzySuggestDescriptor<T> : DescriptorBase<FuzzySuggestDescriptor<T>, IFuzzySuggester>, IFuzzySuggester
		where T : class
	{
		IFuzziness IFuzzySuggester.Fuzziness { get; set; }
		int? IFuzzySuggester.MinLength { get; set; }
		int? IFuzzySuggester.PrefixLength { get; set; }
		bool? IFuzzySuggester.Transpositions { get; set; }
		bool? IFuzzySuggester.UnicodeAware { get; set; }

		public FuzzySuggestDescriptor<T> Fuzziness(Fuzziness fuzziness) => Assign(fuzziness, (a, v) => a.Fuzziness = v);

		public FuzzySuggestDescriptor<T> UnicodeAware(bool? aware = true) => Assign(aware, (a, v) => a.UnicodeAware = v);

		public FuzzySuggestDescriptor<T> Transpositions(bool? transpositions = true) => Assign(transpositions, (a, v) => a.Transpositions = v);

		public FuzzySuggestDescriptor<T> MinLength(int? length) => Assign(length, (a, v) => a.MinLength = v);

		public FuzzySuggestDescriptor<T> PrefixLength(int? length) => Assign(length, (a, v) => a.PrefixLength = v);
	}
}
