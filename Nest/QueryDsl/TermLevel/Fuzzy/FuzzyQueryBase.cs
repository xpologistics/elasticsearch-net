﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(FuzzyQueryJsonConverter))]
	public interface IFuzzyQuery : IFieldNameQuery
	{
		[JsonProperty("max_expansions")]
		int? MaxExpansions { get; set; }

		[JsonProperty("prefix_length")]
		int? PrefixLength { get; set; }

		[JsonProperty("rewrite")]
		MultiTermQueryRewrite Rewrite { get; set; }

		[JsonProperty("transpositions")]
		bool? Transpositions { get; set; }
	}

	public interface IFuzzyQuery<TValue, TFuzziness> : IFuzzyQuery
	{
		[JsonProperty("fuzziness")]
		TFuzziness Fuzziness { get; set; }

		[JsonProperty("value")]
		TValue Value { get; set; }
	}

	internal static class FuzzyQueryBase
	{
		internal static bool IsConditionless<TValue, TFuzziness>(IFuzzyQuery<TValue, TFuzziness> fuzzy) =>
			fuzzy == null || fuzzy.Value == null || fuzzy.Field == null;
	}

	public abstract class FuzzyQueryBase<TValue, TFuzziness> : FieldNameQueryBase, IFuzzyQuery<TValue, TFuzziness>
	{
		public TFuzziness Fuzziness { get; set; }

		public int? MaxExpansions { get; set; }
		public int? PrefixLength { get; set; }

		public MultiTermQueryRewrite Rewrite { get; set; }

		public bool? Transpositions { get; set; }

		public TValue Value { get; set; }

		protected override bool Conditionless => FuzzyQueryBase.IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Fuzzy = this;
	}

	public abstract class FuzzyQueryDescriptorBase<TDescriptor, T, TValue, TFuzziness>
		: FieldNameQueryDescriptorBase<TDescriptor, IFuzzyQuery<TValue, TFuzziness>, T>, IFuzzyQuery<TValue, TFuzziness>
		where T : class
		where TDescriptor : FieldNameQueryDescriptorBase<TDescriptor, IFuzzyQuery<TValue, TFuzziness>, T>, IFuzzyQuery<TValue, TFuzziness>
	{
		protected override bool Conditionless => FuzzyQueryBase.IsConditionless(this);
		TFuzziness IFuzzyQuery<TValue, TFuzziness>.Fuzziness { get; set; }
		int? IFuzzyQuery.MaxExpansions { get; set; }
		int? IFuzzyQuery.PrefixLength { get; set; }
		MultiTermQueryRewrite IFuzzyQuery.Rewrite { get; set; }
		bool? IFuzzyQuery.Transpositions { get; set; }
		TValue IFuzzyQuery<TValue, TFuzziness>.Value { get; set; }

		public TDescriptor MaxExpansions(int? maxExpansions) => Assign(maxExpansions, (a, v) => a.MaxExpansions = v);

		public TDescriptor PrefixLength(int? prefixLength) => Assign(prefixLength, (a, v) => a.PrefixLength = v);

		public TDescriptor Transpositions(bool? enable = true) => Assign(enable, (a, v) => a.Transpositions = v);

		public TDescriptor Rewrite(MultiTermQueryRewrite rewrite) => Assign(rewrite, (a, v) => a.Rewrite = v);
	}
}
