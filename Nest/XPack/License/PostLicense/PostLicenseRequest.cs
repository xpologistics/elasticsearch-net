﻿using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IPostLicenseRequest
	{
		[JsonProperty("license")]
		License License { get; set; }
	}

	public partial class PostLicenseRequest
	{
		public License License { get; set; }

		public static implicit operator PostLicenseRequest(License license) => new PostLicenseRequest { License = license };
	}

	[DescriptorFor("XpackLicensePost")]
	public partial class PostLicenseDescriptor
	{
		License IPostLicenseRequest.License { get; set; }

		public PostLicenseDescriptor License(License license) =>
			Assign(license, (a, v) => a.License = v);
	}
}
