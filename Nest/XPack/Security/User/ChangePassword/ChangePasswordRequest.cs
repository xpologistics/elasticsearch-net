﻿using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IChangePasswordRequest
	{
		[JsonProperty("password")]
		string Password { get; set; }
	}

	public partial class ChangePasswordRequest
	{
		public string Password { get; set; }
	}

	[DescriptorFor("XpackSecurityChangePassword")]
	public partial class ChangePasswordDescriptor
	{
		string IChangePasswordRequest.Password { get; set; }

		public ChangePasswordDescriptor Password(string password) => Assign(password, (a, v) => a.Password = v);
	}
}
