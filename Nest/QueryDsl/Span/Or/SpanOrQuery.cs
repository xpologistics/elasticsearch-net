﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SpanOrQuery>))]
	public interface ISpanOrQuery : ISpanSubQuery
	{
		[JsonProperty("clauses")]
		IEnumerable<ISpanQuery> Clauses { get; set; }
	}

	public class SpanOrQuery : QueryBase, ISpanOrQuery
	{
		public IEnumerable<ISpanQuery> Clauses { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.SpanOr = this;

		internal static bool IsConditionless(ISpanOrQuery q) => !q.Clauses.HasAny() || q.Clauses.Cast<IQuery>().All(qq => qq.Conditionless);
	}

	public class SpanOrQueryDescriptor<T>
		: QueryDescriptorBase<SpanOrQueryDescriptor<T>, ISpanOrQuery>
			, ISpanOrQuery where T : class
	{
		protected override bool Conditionless => SpanOrQuery.IsConditionless(this);
		IEnumerable<ISpanQuery> ISpanOrQuery.Clauses { get; set; }

		public SpanOrQueryDescriptor<T> Clauses(params Func<SpanQueryDescriptor<T>, SpanQueryDescriptor<T>>[] selectors) => Assign(selectors, (a, v) =>
		{
			var clauses = (
				from selector in v
				select selector(new SpanQueryDescriptor<T>())
				into q
				where !(q as IQuery).Conditionless
				select q
			).ToList();
			a.Clauses = clauses.HasAny() ? clauses : null;
		});
	}
}
