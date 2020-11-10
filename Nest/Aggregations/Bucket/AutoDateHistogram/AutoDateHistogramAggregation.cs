using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<AutoDateHistogramAggregation>))]
	public interface IAutoDateHistogramAggregation : IBucketAggregation
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("format")]
		string Format { get; set; }

		[JsonProperty("missing")]
		DateTime? Missing { get; set; }

		[JsonProperty("offset")]
		string Offset { get; set; }

		[JsonProperty("params")]
		IDictionary<string, object> Params { get; set; }

		[JsonProperty("script")]
		IScript Script { get; set; }

		[JsonProperty("time_zone")]
		string TimeZone { get; set; }
	}

	public class AutoDateHistogramAggregation : BucketAggregationBase, IAutoDateHistogramAggregation
	{
		private string _format;

		internal AutoDateHistogramAggregation() { }

		public AutoDateHistogramAggregation(string name) : base(name) { }

		public Field Field { get; set; }

		//see: https://github.com/elastic/elasticsearch/issues/9725
		public string Format
		{
			get => !string.IsNullOrEmpty(_format) &&
				!_format.Contains("date_optional_time") &&
				(Missing.HasValue)
					? _format + "||date_optional_time"
					: _format;
			set => _format = value;
		}

		public DateTime? Missing { get; set; }
		public string Offset { get; set; }
		public IDictionary<string, object> Params { get; set; }
		public IScript Script { get; set; }
		public string TimeZone { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.AutoDateHistogram = this;
	}

	public class AutoDateHistogramAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<AutoDateHistogramAggregationDescriptor<T>, IAutoDateHistogramAggregation, T>
			, IAutoDateHistogramAggregation
		where T : class
	{
		private string _format;

		Field IAutoDateHistogramAggregation.Field { get; set; }

		//see: https://github.com/elastic/elasticsearch/issues/9725
		string IAutoDateHistogramAggregation.Format
		{
			get => !string.IsNullOrEmpty(_format) &&
				!_format.Contains("date_optional_time") &&
				(Self.Missing.HasValue)
					? _format + "||date_optional_time"
					: _format;
			set => _format = value;
		}

		DateTime? IAutoDateHistogramAggregation.Missing { get; set; }

		string IAutoDateHistogramAggregation.Offset { get; set; }

		IDictionary<string, object> IAutoDateHistogramAggregation.Params { get; set; }

		IScript IAutoDateHistogramAggregation.Script { get; set; }

		string IAutoDateHistogramAggregation.TimeZone { get; set; }

		public AutoDateHistogramAggregationDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public AutoDateHistogramAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(field, (a, v) => a.Field = v);

		public AutoDateHistogramAggregationDescriptor<T> Script(string script) => Assign((InlineScript)script, (a, v) => a.Script = v);

		public AutoDateHistogramAggregationDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(scriptSelector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));

		public AutoDateHistogramAggregationDescriptor<T> Format(string format) => Assign(format, (a, v) => a.Format = v);

		public AutoDateHistogramAggregationDescriptor<T> TimeZone(string timeZone) => Assign(timeZone, (a, v) => a.TimeZone = v);

		public AutoDateHistogramAggregationDescriptor<T> Offset(string offset) => Assign(offset, (a, v) => a.Offset = v);

		public AutoDateHistogramAggregationDescriptor<T> Missing(DateTime? missing) => Assign(missing, (a, v) => a.Missing = v);
	}
}
