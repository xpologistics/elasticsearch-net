using System;
using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IStartDatafeedRequest
	{
		/// <summary>
		/// The time that the datafeed should end. This value is exclusive.
		/// </summary>
		[JsonProperty("end")]
		[JsonConverter(typeof(EpochMillisecondsDateTimeJsonConverter))]
		DateTimeOffset? End { get; set; }

		/// <summary>
		/// The time that the datafeed should begin. This value is inclusive.
		/// </summary>
		[JsonProperty("start")]
		[JsonConverter(typeof(EpochMillisecondsDateTimeJsonConverter))]
		DateTimeOffset? Start { get; set; }

		/// <summary>
		/// Controls the amount of time to wait until a datafeed starts.
		/// </summary>
		[JsonProperty("timeout")]
		Time Timeout { get; set; }
	}

	/// <inheritdoc />
	public partial class StartDatafeedRequest
	{
		/// <inheritdoc />
		public DateTimeOffset? End { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? Start { get; set; }

		/// <inheritdoc />
		public Time Timeout { get; set; }
	}

	/// <inheritdoc />
	[DescriptorFor("XpackMlStartDatafeed")]
	public partial class StartDatafeedDescriptor
	{
		DateTimeOffset? IStartDatafeedRequest.End { get; set; }
		DateTimeOffset? IStartDatafeedRequest.Start { get; set; }
		Time IStartDatafeedRequest.Timeout { get; set; }

		/// <inheritdoc />
		public StartDatafeedDescriptor Timeout(Time timeout) => Assign(timeout, (a, v) => a.Timeout = v);

		/// <inheritdoc />
		public StartDatafeedDescriptor Start(DateTimeOffset? start) => Assign(start, (a, v) => a.Start = v);

		/// <inheritdoc />
		public StartDatafeedDescriptor End(DateTimeOffset? end) => Assign(end, (a, v) => a.End = v);
	}
}
