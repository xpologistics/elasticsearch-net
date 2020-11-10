﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(FieldNameQueryJsonConverter<TermRangeQuery>))]
	public interface ITermRangeQuery : IRangeQuery
	{
		[JsonProperty("gt")]
		string GreaterThan { get; set; }

		[JsonProperty("gte")]
		string GreaterThanOrEqualTo { get; set; }

		[JsonProperty("lt")]
		string LessThan { get; set; }

		[JsonProperty("lte")]
		string LessThanOrEqualTo { get; set; }
	}

	public class TermRangeQuery : FieldNameQueryBase, ITermRangeQuery
	{
		public string GreaterThan { get; set; }
		public string GreaterThanOrEqualTo { get; set; }
		public string LessThan { get; set; }
		public string LessThanOrEqualTo { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Range = this;

		internal static bool IsConditionless(ITermRangeQuery q) => q.Field.IsConditionless()
			|| q.GreaterThanOrEqualTo.IsNullOrEmpty()
			&& q.LessThanOrEqualTo.IsNullOrEmpty()
			&& q.GreaterThan.IsNullOrEmpty()
			&& q.LessThan.IsNullOrEmpty();
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class TermRangeQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<TermRangeQueryDescriptor<T>, ITermRangeQuery, T>
			, ITermRangeQuery where T : class
	{
		protected override bool Conditionless => TermRangeQuery.IsConditionless(this);
		string ITermRangeQuery.GreaterThan { get; set; }
		string ITermRangeQuery.GreaterThanOrEqualTo { get; set; }
		string ITermRangeQuery.LessThan { get; set; }
		string ITermRangeQuery.LessThanOrEqualTo { get; set; }

		public TermRangeQueryDescriptor<T> GreaterThan(string from) => Assign(from, (a, v) => a.GreaterThan = v);

		public TermRangeQueryDescriptor<T> GreaterThanOrEquals(string from) => Assign(from, (a, v) => a.GreaterThanOrEqualTo = v);

		public TermRangeQueryDescriptor<T> LessThan(string to) => Assign(to, (a, v) => a.LessThan = v);

		public TermRangeQueryDescriptor<T> LessThanOrEquals(string to) => Assign(to, (a, v) => a.LessThanOrEqualTo = v);
	}
}
