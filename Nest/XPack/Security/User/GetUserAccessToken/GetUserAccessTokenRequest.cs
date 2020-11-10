﻿using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IGetUserAccessTokenRequest
	{
		[JsonProperty("grant_type")]
		AccessTokenGrantType? GrantType { get; set; }

		[JsonProperty("password")]
		string Password { get; set; }

		[JsonProperty("scope")]
		string Scope { get; set; }

		[JsonProperty("username")]
		string Username { get; set; }
	}

	public partial class GetUserAccessTokenRequest
	{
		public GetUserAccessTokenRequest(string username, string password)
		{
			var self = (IGetUserAccessTokenRequest)this;
			self.Username = username;
			self.Password = password;
		}

		public AccessTokenGrantType? GrantType { get; set; } = AccessTokenGrantType.Password;

		public string Scope { get; set; }

		[JsonProperty("password")]
		string IGetUserAccessTokenRequest.Password { get; set; }

		[JsonProperty("username")]
		string IGetUserAccessTokenRequest.Username { get; set; }
	}

	[DescriptorFor("XpackSecurityGetToken")]
	public partial class GetUserAccessTokenDescriptor
	{
		public GetUserAccessTokenDescriptor(string username, string password)
		{
			var self = (IGetUserAccessTokenRequest)this;
			self.Username = username;
			self.Password = password;
		}

		AccessTokenGrantType? IGetUserAccessTokenRequest.GrantType { get; set; } = AccessTokenGrantType.Password;
		string IGetUserAccessTokenRequest.Password { get; set; }
		string IGetUserAccessTokenRequest.Scope { get; set; }
		string IGetUserAccessTokenRequest.Username { get; set; }

		public GetUserAccessTokenDescriptor GrantType(AccessTokenGrantType? type) => Assign(type, (a, v) => a.GrantType = v);

		public GetUserAccessTokenDescriptor Scope(string scope) => Assign(scope, (a, v) => a.Scope = v);
	}
}
