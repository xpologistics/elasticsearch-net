using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Retrieve results for machine learning job influencers.
	/// </summary>
	public partial interface IGetInfluencersRequest
	{
		/// <summary>
		/// If true, the results are sorted in descending order.
		/// </summary>
		bool? Descending { get; set; }

		/// <summary>
		/// Returns influencers with timestamps earlier than this time.
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
		/// Returns influencers with anomaly scores higher than this value.
		/// </summary>
		[JsonProperty("influencer_score")]
		double? InfluencerScore { get; set; }

		/// <summary>
		/// Specifies pagination for the influencers.
		/// </summary>
		[JsonProperty("page")]
		IPage Page { get; set; }

		/// <summary>
		/// Specifies the sort field for the requested influencers. By default, the influencers are sorted by the <see cref="InfluencerScore" /> value.
		/// </summary>
		[JsonProperty("sort")]
		Field Sort { get; set; }

		/// <summary>
		/// Returns influencers with timestamps after this time.
		/// </summary>
		[JsonProperty("start")]
		[JsonConverter(typeof(EpochMillisecondsDateTimeJsonConverter))]
		DateTimeOffset? Start { get; set; }
	}

	/// <inheritdoc />
	public partial class GetInfluencersRequest
	{
		/// <inheritdoc />
		public bool? Descending { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? End { get; set; }

		/// <inheritdoc />
		public bool? ExcludeInterim { get; set; }

		/// <inheritdoc />
		public double? InfluencerScore { get; set; }

		/// <inheritdoc />
		public IPage Page { get; set; }

		/// <inheritdoc />
		public Field Sort { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? Start { get; set; }
	}

	/// <inheritdoc />
	[DescriptorFor("XpackMlGetInfluencers")]
	public partial class GetInfluencersDescriptor
	{
		public GetInfluencersDescriptor() { }

		bool? IGetInfluencersRequest.Descending { get; set; }
		DateTimeOffset? IGetInfluencersRequest.End { get; set; }
		bool? IGetInfluencersRequest.ExcludeInterim { get; set; }
		double? IGetInfluencersRequest.InfluencerScore { get; set; }
		IPage IGetInfluencersRequest.Page { get; set; }
		Field IGetInfluencersRequest.Sort { get; set; }
		DateTimeOffset? IGetInfluencersRequest.Start { get; set; }

		/// <inheritdoc />
		public GetInfluencersDescriptor InfluencerScore(double? influencerScore) => Assign(influencerScore, (a, v) => a.InfluencerScore = v);

		/// <inheritdoc />
		public GetInfluencersDescriptor Desc(bool? descending = true) => Assign(descending, (a, v) => a.Descending = v);

		/// <inheritdoc />
		public GetInfluencersDescriptor End(DateTimeOffset? end) => Assign(end, (a, v) => a.End = v);

		/// <inheritdoc />
		public GetInfluencersDescriptor ExcludeInterim(bool? excludeInterim = true) => Assign(excludeInterim, (a, v) => a.ExcludeInterim = v);

		/// <inheritdoc />
		public GetInfluencersDescriptor Page(Func<PageDescriptor, IPage> selector) => Assign(selector, (a, v) => a.Page = v?.Invoke(new PageDescriptor()));

		/// <inheritdoc />
		public GetInfluencersDescriptor Sort(Field field) => Assign(field, (a, v) => a.Sort = v);

		/// <inheritdoc />
		public GetInfluencersDescriptor Start(DateTimeOffset? end) => Assign(end, (a, v) => a.Start = v);
	}
}
