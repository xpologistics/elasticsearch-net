﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SpanContainingQuery>))]
	public interface ISpanContainingQuery : ISpanSubQuery
	{
		[JsonProperty("big")]
		ISpanQuery Big { get; set; }

		[JsonProperty("little")]
		ISpanQuery Little { get; set; }
	}

	public class SpanContainingQuery : QueryBase, ISpanContainingQuery
	{
		public ISpanQuery Big { get; set; }
		public ISpanQuery Little { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.SpanContaining = this;

		internal static bool IsConditionless(ISpanContainingQuery q)
		{
			var exclude = q.Little as IQuery;
			var include = q.Big as IQuery;

			return exclude == null && include == null
				|| include == null && exclude.Conditionless
				|| exclude == null && include.Conditionless
				|| exclude != null && exclude.Conditionless && include != null && include.Conditionless;
		}
	}

	public class SpanContainingQueryDescriptor<T>
		: QueryDescriptorBase<SpanContainingQueryDescriptor<T>, ISpanContainingQuery>
			, ISpanContainingQuery where T : class
	{
		protected override bool Conditionless => SpanContainingQuery.IsConditionless(this);
		ISpanQuery ISpanContainingQuery.Big { get; set; }
		ISpanQuery ISpanContainingQuery.Little { get; set; }

		public SpanContainingQueryDescriptor<T> Little(Func<SpanQueryDescriptor<T>, ISpanQuery> selector) =>
			Assign(selector(new SpanQueryDescriptor<T>()), (a, v) => a.Little = v);

		public SpanContainingQueryDescriptor<T> Big(Func<SpanQueryDescriptor<T>, ISpanQuery> selector) =>
			Assign(selector(new SpanQueryDescriptor<T>()), (a, v) => a.Big = v);
	}
}
