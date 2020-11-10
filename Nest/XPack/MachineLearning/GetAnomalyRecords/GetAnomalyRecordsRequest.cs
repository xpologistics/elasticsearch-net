using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Retrieve anomaly records for a machine learning job.
	/// </summary>
	public partial interface IGetAnomalyRecordsRequest
	{
		/// <summary>
		/// If true, the results are sorted in descending order.
		/// </summary>
		[JsonProperty("desc")]
		bool? Descending { get; set; }

		/// <summary>
		/// Returns records with timestamps earlier than this time.
		/// </summary>
		[JsonProperty("end")]
		[JsonConverter(typeof(EpochMillisecondsDateTimeJsonConverter))]
		DateTimeOffset? End { get; set; }

		/// <summary>
		/// If true, the output excludes interim results. By default, interim results are included.
		/// </summary>
		[JsonProperty("exclude_interim")]
		bool? ExcludeInterim { get; set; }

		/// <summary>
		/// Specifies pagination for the records
		/// </summary>
		[JsonProperty("page")]
		IPage Page { get; set; }

		/// <summary>
		/// Returns records with anomaly scores higher than this value.
		/// </summary>
		[JsonProperty("record_score")]
		double? RecordScore { get; set; }

		/// <summary>
		/// Specifies the sort field for the requested records. By default, records are sorted by the anomaly score value.
		/// </summary>
		[JsonProperty("sort")]
		Field Sort { get; set; }

		/// <summary>
		/// Returns records with timestamps after this time.
		/// </summary>
		[JsonProperty("start")]
		[JsonConverter(typeof(EpochMillisecondsDateTimeJsonConverter))]
		DateTimeOffset? Start { get; set; }
	}

	/// <inheritdoc />
	public partial class GetAnomalyRecordsRequest
	{
		/// <inheritdoc />
		public bool? Descending { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? End { get; set; }

		/// <inheritdoc />
		public bool? ExcludeInterim { get; set; }

		/// <inheritdoc />
		public IPage Page { get; set; }

		/// <inheritdoc />
		public double? RecordScore { get; set; }

		/// <inheritdoc />
		public Field Sort { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? Start { get; set; }
	}

	/// <inheritdoc />
	[DescriptorFor("XpackMlGetRecords")]
	public partial class GetAnomalyRecordsDescriptor
	{
		public GetAnomalyRecordsDescriptor() : base() { }

		bool? IGetAnomalyRecordsRequest.Descending { get; set; }
		DateTimeOffset? IGetAnomalyRecordsRequest.End { get; set; }
		bool? IGetAnomalyRecordsRequest.ExcludeInterim { get; set; }
		IPage IGetAnomalyRecordsRequest.Page { get; set; }
		double? IGetAnomalyRecordsRequest.RecordScore { get; set; }
		Field IGetAnomalyRecordsRequest.Sort { get; set; }
		DateTimeOffset? IGetAnomalyRecordsRequest.Start { get; set; }

		/// <inheritdoc />
		public GetAnomalyRecordsDescriptor Descending(bool? descending = true) => Assign(descending, (a, v) => a.Descending = v);

		/// <inheritdoc />
		public GetAnomalyRecordsDescriptor End(DateTimeOffset? end) => Assign(end, (a, v) => a.End = v);

		/// <inheritdoc />
		public GetAnomalyRecordsDescriptor Page(Func<PageDescriptor, IPage> selector) =>
			Assign(selector, (a, v) => a.Page = v?.Invoke(new PageDescriptor()));

		/// <inheritdoc />
		public GetAnomalyRecordsDescriptor Sort(Field field) => Assign(field, (a, v) => a.Sort = v);

		/// <inheritdoc />
		public GetAnomalyRecordsDescriptor Start(DateTimeOffset? end) => Assign(end, (a, v) => a.Start = v);

		/// <inheritdoc />
		public GetAnomalyRecordsDescriptor ExcludeInterim(bool? excludeInterim = true) =>
			Assign(excludeInterim, (a, v) => a.ExcludeInterim = v);

		/// <inheritdoc />
		public GetAnomalyRecordsDescriptor RecordScore(double? recordScore) =>
			Assign(recordScore, (a, v) => a.RecordScore = v);
	}
}
