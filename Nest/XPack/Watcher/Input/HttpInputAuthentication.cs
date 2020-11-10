﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// The Authentication mechanism for a request to a HTTP endpoint
	/// </summary>
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<HttpInputAuthentication>))]
	public interface IHttpInputAuthentication
	{
		/// <summary>
		/// Basic Authentication credentials
		/// </summary>
		[JsonProperty("basic")]
		IHttpInputBasicAuthentication Basic { get; set; }
	}

	/// <inheritdoc />
	public class HttpInputAuthentication : IHttpInputAuthentication
	{
		/// <inheritdoc />
		public IHttpInputBasicAuthentication Basic { get; set; }
	}

	/// <inheritdoc />
	public class HttpInputAuthenticationDescriptor
		: DescriptorBase<HttpInputAuthenticationDescriptor, IHttpInputAuthentication>, IHttpInputAuthentication
	{
		IHttpInputBasicAuthentication IHttpInputAuthentication.Basic { get; set; }

		/// <inheritdoc />
		public HttpInputAuthenticationDescriptor Basic(Func<HttpInputBasicAuthenticationDescriptor, IHttpInputBasicAuthentication> selector) =>
			Assign(selector.Invoke(new HttpInputBasicAuthenticationDescriptor()), (a, v) => a.Basic = v);
	}

	/// <summary>
	/// Basic Authentication credentials
	/// </summary>
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<HttpInputBasicAuthentication>))]
	public interface IHttpInputBasicAuthentication
	{
		/// <summary>
		/// Password for Basic Authentication
		/// </summary>
		[JsonProperty("password")]
		string Password { get; set; }

		/// <summary>
		/// Username for Basic Authentication
		/// </summary>
		[JsonProperty("username")]
		string Username { get; set; }
	}

	/// <inheritdoc />
	[JsonObject]
	public class HttpInputBasicAuthentication : IHttpInputBasicAuthentication
	{
		/// <inheritdoc />
		public string Password { get; set; }

		/// <inheritdoc />
		public string Username { get; set; }
	}

	/// <inheritdoc />
	public class HttpInputBasicAuthenticationDescriptor
		: DescriptorBase<HttpInputBasicAuthenticationDescriptor, IHttpInputBasicAuthentication>, IHttpInputBasicAuthentication
	{
		string IHttpInputBasicAuthentication.Password { get; set; }
		string IHttpInputBasicAuthentication.Username { get; set; }

		/// <inheritdoc />
		public HttpInputBasicAuthenticationDescriptor Username(string username) =>
			Assign(username, (a, v) => a.Username = v);

		/// <inheritdoc />
		public HttpInputBasicAuthenticationDescriptor Password(string password) =>
			Assign(password, (a, v) => a.Password = v);
	}
}
