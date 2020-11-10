﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SpanFirstQueryDescriptor<object>>))]
	public interface ISpanFirstQuery : ISpanSubQuery
	{
		[JsonProperty("end")]
		int? End { get; set; }

		[JsonProperty("match")]
		ISpanQuery Match { get; set; }
	}

	public class SpanFirstQuery : QueryBase, ISpanFirstQuery
	{
		public int? End { get; set; }
		public ISpanQuery Match { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.SpanFirst = this;

		internal static bool IsConditionless(ISpanFirstQuery q) => q.Match == null || q.Match.Conditionless;
	}

	public class SpanFirstQueryDescriptor<T>
		: QueryDescriptorBase<SpanFirstQueryDescriptor<T>, ISpanFirstQuery>
			, ISpanFirstQuery where T : class
	{
		protected override bool Conditionless => SpanFirstQuery.IsConditionless(this);
		int? ISpanFirstQuery.End { get; set; }
		ISpanQuery ISpanFirstQuery.Match { get; set; }

		public SpanFirstQueryDescriptor<T> Match(Func<SpanQueryDescriptor<T>, ISpanQuery> selector) =>
			Assign(selector(new SpanQueryDescriptor<T>()), (a, v) => a.Match = v);

		public SpanFirstQueryDescriptor<T> End(int? end) => Assign(end, (a, v) => a.End = v);
	}
}
