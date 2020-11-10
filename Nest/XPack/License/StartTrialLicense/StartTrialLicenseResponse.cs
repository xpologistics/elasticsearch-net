using Newtonsoft.Json;

namespace Nest6
{
	public interface IStartTrialLicenseResponse : IAcknowledgedResponse
	{
		[JsonProperty("error_message")]
		string ErrorMessage { get; }

		[JsonProperty("trial_was_started")]
		bool TrialWasStarted { get; }
	}

	public class StartTrialLicenseResponse : AcknowledgedResponseBase, IStartTrialLicenseResponse
	{
		public string ErrorMessage { get; internal set; }
		public bool TrialWasStarted { get; internal set; }
	}
}
