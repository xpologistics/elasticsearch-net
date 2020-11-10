﻿using Newtonsoft.Json;

namespace Nest6
{
	public interface IGetUserAccessTokenResponse : IResponse
	{
		[JsonProperty("access_token")]
		string AccessToken { get; set; }

		[JsonProperty("expires_in")]
		long ExpiresIn { get; set; }

		[JsonProperty("scope")]
		string Scope { get; set; }

		[JsonProperty("type")]
		string Type { get; set; }
	}

	public class GetUserAccessTokenResponse : ResponseBase, IGetUserAccessTokenResponse
	{
		public string AccessToken { get; set; }
		public long ExpiresIn { get; set; }
		public string Scope { get; set; }
		public string Type { get; set; }
	}
}
