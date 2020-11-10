﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	public partial interface ICreateApiKeyRequest
	{
		/// <summary>
		/// Optional expiration for the API key being generated.
		/// If expiration is not provided then the API keys do not expire.
		/// </summary>
		[JsonProperty("expiration")]
		Time Expiration { get; set; }

		/// <summary>
		/// Name for this API key
		/// </summary>
		[JsonProperty("name")]
		string Name { get; set; }

		/// <summary>
		/// Optional role descriptors for this API key, if not provided then permissions of authenticated user are applied.
		/// </summary>
		[JsonProperty("role_descriptors")]
		IApiKeyRoles Roles { get; set; }
	}

	public partial class CreateApiKeyRequest
	{
		/// <inheritdoc cref="ICreateApiKeyRequest.Expiration" />
		public Time Expiration { get; set; }

		/// <inheritdoc cref="ICreateApiKeyRequest.Name" />
		public string Name { get; set; }

		/// <inheritdoc cref="ICreateApiKeyRequest.Roles" />
		public IApiKeyRoles Roles { get; set; } = new ApiKeyRoles(); // Ensure not null, as server expects {}
	}

	[DescriptorFor("XpackSecurityCreateApiKey")]
	public partial class CreateApiKeyDescriptor
	{
		/// <inheritdoc cref="ICreateApiKeyRequest.Expiration" />
		Time ICreateApiKeyRequest.Expiration { get; set; }

		/// <inheritdoc cref="ICreateApiKeyRequest.Name" />
		string ICreateApiKeyRequest.Name { get; set; }

		/// <inheritdoc cref="ICreateApiKeyRequest.Roles" />
		IApiKeyRoles ICreateApiKeyRequest.Roles { get; set; } = new ApiKeyRoles(); // Ensure not null, as server expects {}

		/// <inheritdoc cref="ICreateApiKeyRequest.Expiration" />
		public CreateApiKeyDescriptor Expiration(Time expiration) => Assign(expiration, (a, v) => a.Expiration = v);

		/// <inheritdoc cref="ICreateApiKeyRequest.Name" />
		public CreateApiKeyDescriptor Name(string name) => Assign(name, (a, v) => a.Name = v);

		/// <inheritdoc cref="ICreateApiKeyRequest.Roles" />
		public CreateApiKeyDescriptor Roles(Func<ApiKeyRolesDescriptor, IPromise<IApiKeyRoles>> selector) =>
			Assign(selector, (a, v) => a.Roles = v.InvokeOrDefault(new ApiKeyRolesDescriptor()).Value);
	}
}
