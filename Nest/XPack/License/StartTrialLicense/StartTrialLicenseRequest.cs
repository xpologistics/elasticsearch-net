﻿namespace Nest6
{
	public partial interface IStartTrialLicenseRequest { }

	public partial class StartTrialLicenseRequest { }

	[DescriptorFor("XpackLicensePostStartTrial")]
	public partial class StartTrialLicenseDescriptor : IStartTrialLicenseRequest { }
}
