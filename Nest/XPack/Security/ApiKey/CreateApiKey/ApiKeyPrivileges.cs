using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<ApiKeyPrivileges>))]
	public interface IApiKeyPrivileges
	{
		/// <summary>
		/// A list of names.
		/// </summary>
		[JsonProperty("names")]
		IEnumerable<string> Names { get; set; }

		/// <summary>
		/// A list of privileges.
		/// </summary>
		[JsonProperty("privileges")]
		IEnumerable<string> Privileges { get; set; }
	}

	public class ApiKeyPrivileges : IApiKeyPrivileges
	{
		/// <inheritdoc cref="IApiKeyPrivileges.Names" />
		public IEnumerable<string> Names { get; set; }

		/// <inheritdoc cref="IApiKeyPrivileges.Privileges" />
		public IEnumerable<string> Privileges { get; set; }
	}

	public class ApiKeyPrivilegesDescriptor
		: DescriptorPromiseBase<ApiKeyPrivilegesDescriptor, List<IApiKeyPrivileges>>
	{
		public ApiKeyPrivilegesDescriptor() : base(new List<IApiKeyPrivileges>()) { }

		public ApiKeyPrivilegesDescriptor Index(Func<ApiKeyPrivilegeDescriptor, IApiKeyPrivileges> selector) =>
			Assign(selector, (a, v) => a.Add(v.InvokeOrDefault(new ApiKeyPrivilegeDescriptor())));

		public class ApiKeyPrivilegeDescriptor
			: DescriptorBase<ApiKeyPrivilegeDescriptor, IApiKeyPrivileges>, IApiKeyPrivileges
		{
			/// <inheritdoc cref="IApiKeyPrivileges.Names" />
			IEnumerable<string> IApiKeyPrivileges.Names { get; set; }

			/// <inheritdoc cref="IApiKeyPrivileges.Privileges" />
			IEnumerable<string> IApiKeyPrivileges.Privileges { get; set; }

			/// <inheritdoc cref="IApiKeyPrivileges.Privileges" />
			public ApiKeyPrivilegeDescriptor Privileges(params string[] privileges) => Assign(privileges, (a, v) => a.Privileges = v);

			/// <inheritdoc cref="IApiKeyPrivileges.Privileges" />
			public ApiKeyPrivilegeDescriptor Privileges(IEnumerable<string> privileges) => Assign(privileges, (a, v) => a.Privileges = v);

			/// <inheritdoc cref="IApiKeyPrivileges.Names" />
			public ApiKeyPrivilegeDescriptor Names(params string[] resources) => Assign(resources, (a, v) => a.Names = v);

			/// <inheritdoc cref="IApiKeyPrivileges.Names" />
			public ApiKeyPrivilegeDescriptor Names(IEnumerable<string> resources) => Assign(resources, (a, v) => a.Names = v);
		}
	}
}
