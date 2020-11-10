using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IStopDatafeedRequest
	{
		/// <summary>
		/// If true, the datafeed is stopped forcefully.
		/// </summary>
		[JsonProperty("force")]
		bool? Force { get; set; }

		/// <summary>
		/// Controls the amount of time to wait until a datafeed stops.
		/// </summary>
		[JsonProperty("timeout")]
		Time Timeout { get; set; }
	}

	/// <inheritdoc />
	public partial class StopDatafeedRequest
	{
		/// <inheritdoc />
		public bool? Force { get; set; }

		/// <inheritdoc />
		public Time Timeout { get; set; }
	}

	/// <inheritdoc />
	[DescriptorFor("XpackMlStopDatafeed")]
	public partial class StopDatafeedDescriptor
	{
		bool? IStopDatafeedRequest.Force { get; set; }
		Time IStopDatafeedRequest.Timeout { get; set; }

		/// <inheritdoc />
		public StopDatafeedDescriptor Timeout(Time timeout) => Assign(timeout, (a, v) => a.Timeout = v);

		/// <inheritdoc />
		public StopDatafeedDescriptor Force(bool? force = true) => Assign(force, (a, v) => a.Force = v);
	}
}
