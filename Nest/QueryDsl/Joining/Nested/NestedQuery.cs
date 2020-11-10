﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<NestedQueryDescriptor<object>>))]
	public interface INestedQuery : IQuery
	{
		[JsonProperty("ignore_unmapped")]
		bool? IgnoreUnmapped { get; set; }

		[JsonProperty("inner_hits")]
		IInnerHits InnerHits { get; set; }

		[JsonProperty("path")]
		Field Path { get; set; }

		[JsonProperty("query")]
		QueryContainer Query { get; set; }

		[JsonProperty("score_mode")]
		NestedScoreMode? ScoreMode { get; set; }
	}

	public class NestedQuery : QueryBase, INestedQuery
	{
		public bool? IgnoreUnmapped { get; set; }
		public IInnerHits InnerHits { get; set; }
		public Field Path { get; set; }
		public QueryContainer Query { get; set; }
		public NestedScoreMode? ScoreMode { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Nested = this;

		internal static bool IsConditionless(INestedQuery q) => q.Path == null || q.Query.IsConditionless();
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class NestedQueryDescriptor<T>
		: QueryDescriptorBase<NestedQueryDescriptor<T>, INestedQuery>
			, INestedQuery where T : class
	{
		protected override bool Conditionless => NestedQuery.IsConditionless(this);
		bool? INestedQuery.IgnoreUnmapped { get; set; }
		IInnerHits INestedQuery.InnerHits { get; set; }
		Field INestedQuery.Path { get; set; }
		QueryContainer INestedQuery.Query { get; set; }
		NestedScoreMode? INestedQuery.ScoreMode { get; set; }

		public NestedQueryDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(selector, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<T>()));

		public NestedQueryDescriptor<T> ScoreMode(NestedScoreMode? scoreMode) => Assign(scoreMode, (a, v) => a.ScoreMode = v);

		public NestedQueryDescriptor<T> Path(Field path) => Assign(path, (a, v) => a.Path = v);

		public NestedQueryDescriptor<T> Path(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.Path = v);

		public NestedQueryDescriptor<T> InnerHits(Func<InnerHitsDescriptor<T>, IInnerHits> selector = null) =>
			Assign(selector.InvokeOrDefault(new InnerHitsDescriptor<T>()), (a, v) => a.InnerHits = v);

		public NestedQueryDescriptor<T> IgnoreUnmapped(bool? ignoreUnmapped = true) =>
			Assign(ignoreUnmapped, (a, v) => a.IgnoreUnmapped = v);
	}
}
