﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SpanMultiTermQuery>))]
	public interface ISpanMultiTermQuery : ISpanSubQuery
	{
		[JsonProperty("match")]
		QueryContainer Match { get; set; }
	}

	public class SpanMultiTermQuery : QueryBase, ISpanMultiTermQuery
	{
		public QueryContainer Match { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.SpanMultiTerm = this;

		internal static bool IsConditionless(ISpanMultiTermQuery q) => q.Match == null || q.Match.IsConditionless;
	}

	public class SpanMultiTermQueryDescriptor<T>
		: QueryDescriptorBase<SpanMultiTermQueryDescriptor<T>, ISpanMultiTermQuery>
			, ISpanMultiTermQuery
		where T : class
	{
		protected override bool Conditionless => SpanMultiTermQuery.IsConditionless(this);
		QueryContainer ISpanMultiTermQuery.Match { get; set; }

		public SpanMultiTermQueryDescriptor<T> Match(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(selector, (a, v) => a.Match = v?.Invoke(new QueryContainerDescriptor<T>()));
	}
}
