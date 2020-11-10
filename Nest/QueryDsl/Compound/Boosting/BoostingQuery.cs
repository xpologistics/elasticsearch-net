﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<BoostingQueryDescriptor<object>>))]
	public interface IBoostingQuery : IQuery
	{
		[JsonProperty("negative_boost")]
		double? NegativeBoost { get; set; }

		[JsonProperty("negative")]
		QueryContainer NegativeQuery { get; set; }

		[JsonProperty("positive")]
		QueryContainer PositiveQuery { get; set; }
	}

	public class BoostingQuery : QueryBase, IBoostingQuery
	{
		public double? NegativeBoost { get; set; }
		public QueryContainer NegativeQuery { get; set; }
		public QueryContainer PositiveQuery { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Boosting = this;

		internal static bool IsConditionless(IBoostingQuery q) => q.NegativeQuery.NotWritable() && q.PositiveQuery.NotWritable();
	}

	public class BoostingQueryDescriptor<T>
		: QueryDescriptorBase<BoostingQueryDescriptor<T>, IBoostingQuery>
			, IBoostingQuery where T : class
	{
		protected override bool Conditionless => BoostingQuery.IsConditionless(this);
		double? IBoostingQuery.NegativeBoost { get; set; }
		QueryContainer IBoostingQuery.NegativeQuery { get; set; }
		QueryContainer IBoostingQuery.PositiveQuery { get; set; }

		public BoostingQueryDescriptor<T> NegativeBoost(double? boost) => Assign(boost, (a, v) => a.NegativeBoost = v);

		public BoostingQueryDescriptor<T> Positive(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(selector, (a, v) => a.PositiveQuery = v?.Invoke(new QueryContainerDescriptor<T>()));

		public BoostingQueryDescriptor<T> Negative(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(selector, (a, v) => a.NegativeQuery = v?.Invoke(new QueryContainerDescriptor<T>()));
	}
}
