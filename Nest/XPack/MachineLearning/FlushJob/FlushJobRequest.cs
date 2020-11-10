using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	public partial interface IFlushJobRequest
	{
		/// <summary>
		/// Specifies that no data prior to this date is expected.
		/// </summary>
		[JsonProperty("advance_time")]
		// Forced to prevent override, ML API always expects ISO8601 format
		[JsonConverter(typeof(IsoDateTimeConverter))]
		DateTimeOffset? AdvanceTime { get; set; }

		/// <summary>
		/// Calculates the interim results for the most recent bucket or all buckets within the latency period.
		/// </summary>
		[JsonProperty("calc_interim")]
		bool? CalculateInterim { get; set; }

		/// <summary>
		///  When used in conjunction with <see cref="CalculateInterim" />, specifies the range of buckets on
		/// which to calculate interim results.
		/// </summary>
		[JsonProperty("end")]
		// Forced to prevent override, ML API always expects ISO8601 format
		[JsonConverter(typeof(IsoDateTimeConverter))]
		DateTimeOffset? End { get; set; }

		/// <summary>
		/// When used in conjunction with <see cref="CalculateInterim" />, specifies the range of buckets
		/// on which to calculate interim results.
		/// </summary>
		[JsonProperty("start")]
		// Forced to prevent override, ML API always expects ISO8601 format
		[JsonConverter(typeof(IsoDateTimeConverter))]
		DateTimeOffset? Start { get; set; }
	}

	public partial class FlushJobRequest
	{
		/// <inheritdoc />
		public DateTimeOffset? AdvanceTime { get; set; }

		/// <inheritdoc />
		public bool? CalculateInterim { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? End { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? Start { get; set; }
	}

	[DescriptorFor("XpackMlFlushJob")]
	public partial class FlushJobDescriptor
	{
		DateTimeOffset? IFlushJobRequest.AdvanceTime { get; set; }
		bool? IFlushJobRequest.CalculateInterim { get; set; }
		DateTimeOffset? IFlushJobRequest.End { get; set; }
		DateTimeOffset? IFlushJobRequest.Start { get; set; }

		/// <inheritdoc />
		public FlushJobDescriptor AdvanceTime(DateTimeOffset? advanceTime) => Assign(advanceTime, (a, v) => a.AdvanceTime = v);

		/// <inheritdoc />
		public FlushJobDescriptor CalculateInterim(bool? calculateInterim = true) => Assign(calculateInterim, (a, v) => a.CalculateInterim = v);

		/// <inheritdoc />
		public FlushJobDescriptor End(DateTimeOffset? end) => Assign(end, (a, v) => a.End = v);

		/// <inheritdoc />
		public FlushJobDescriptor Start(DateTimeOffset? start) => Assign(start, (a, v) => a.Start = v);
	}
}
