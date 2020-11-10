using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<RangeAggregation>))]
	public interface IRangeAggregation : IBucketAggregation
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("ranges")]
		IEnumerable<IAggregationRange> Ranges { get; set; }

		[JsonProperty("script")]
		IScript Script { get; set; }
	}

	public class RangeAggregation : BucketAggregationBase, IRangeAggregation
	{
		internal RangeAggregation() { }

		public RangeAggregation(string name) : base(name) { }

		public Field Field { get; set; }
		public IEnumerable<IAggregationRange> Ranges { get; set; }
		public IScript Script { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Range = this;
	}

	public class RangeAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<RangeAggregationDescriptor<T>, IRangeAggregation, T>, IRangeAggregation
		where T : class
	{
		Field IRangeAggregation.Field { get; set; }

		IEnumerable<IAggregationRange> IRangeAggregation.Ranges { get; set; }

		IScript IRangeAggregation.Script { get; set; }

		public RangeAggregationDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public RangeAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(field, (a, v) => a.Field = v);

		public RangeAggregationDescriptor<T> Script(string script) => Assign((InlineScript)script, (a, v) => a.Script = v);

		public RangeAggregationDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(scriptSelector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));

		public RangeAggregationDescriptor<T> Ranges(params Func<AggregationRangeDescriptor, IAggregationRange>[] ranges) =>
			Assign(ranges.Select(r => r(new AggregationRangeDescriptor())), (a, v) => a.Ranges = v);
	}
}
