﻿using Newtonsoft.Json;

namespace Nest6
{
	public interface INumericRangeQuery : IRangeQuery
	{
		[JsonProperty("gt")]
		double? GreaterThan { get; set; }

		[JsonProperty("gte")]
		double? GreaterThanOrEqualTo { get; set; }

		[JsonProperty("lt")]
		double? LessThan { get; set; }

		[JsonProperty("lte")]
		double? LessThanOrEqualTo { get; set; }

		[JsonProperty("relation")]
		RangeRelation? Relation { get; set; }
	}

	public class NumericRangeQuery : FieldNameQueryBase, INumericRangeQuery
	{
		public double? GreaterThan { get; set; }
		public double? GreaterThanOrEqualTo { get; set; }
		public double? LessThan { get; set; }
		public double? LessThanOrEqualTo { get; set; }

		public RangeRelation? Relation { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Range = this;

		internal static bool IsConditionless(INumericRangeQuery q) => q.Field.IsConditionless()
			|| q.GreaterThanOrEqualTo == null
			&& q.LessThanOrEqualTo == null
			&& q.GreaterThan == null
			&& q.LessThan == null;
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class NumericRangeQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<NumericRangeQueryDescriptor<T>, INumericRangeQuery, T>
			, INumericRangeQuery where T : class
	{
		protected override bool Conditionless => NumericRangeQuery.IsConditionless(this);
		double? INumericRangeQuery.GreaterThan { get; set; }
		double? INumericRangeQuery.GreaterThanOrEqualTo { get; set; }
		double? INumericRangeQuery.LessThan { get; set; }
		double? INumericRangeQuery.LessThanOrEqualTo { get; set; }

		RangeRelation? INumericRangeQuery.Relation { get; set; }

		public NumericRangeQueryDescriptor<T> GreaterThan(double? from) => Assign(from, (a, v) => a.GreaterThan = v);

		public NumericRangeQueryDescriptor<T> GreaterThanOrEquals(double? from) => Assign(from, (a, v) => a.GreaterThanOrEqualTo = v);

		public NumericRangeQueryDescriptor<T> LessThan(double? to) => Assign(to, (a, v) => a.LessThan = v);

		public NumericRangeQueryDescriptor<T> LessThanOrEquals(double? to) => Assign(to, (a, v) => a.LessThanOrEqualTo = v);

		public NumericRangeQueryDescriptor<T> Relation(RangeRelation? relation) => Assign(relation, (a, v) => a.Relation = v);
	}
}
