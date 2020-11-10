using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Privileges for an application
	/// </summary>
	[JsonConverter(typeof(ReadAsTypeJsonConverter<ApplicationPrivileges>))]
	public interface IApplicationPrivileges
	{
		/// <summary>
		/// The name of the application to which this entry applies
		/// </summary>
		[JsonProperty("application")]
		string Application { get; set; }

		/// <summary>
		/// A list of strings, where each element is the name of an application privilege or action.
		/// </summary>
		[JsonProperty("privileges")]
		IEnumerable<string> Privileges { get; set; }

		/// <summary>
		/// A list resources to which the privileges are applied.
		/// </summary>
		[JsonProperty("resources")]
		IEnumerable<string> Resources { get; set; }
	}

	/// <inheritdoc />
	public class ApplicationPrivileges : IApplicationPrivileges
	{
		/// <inheritdoc />
		public string Application { get; set; }

		/// <inheritdoc />
		public IEnumerable<string> Privileges { get; set; }

		/// <inheritdoc />
		public IEnumerable<string> Resources { get; set; }
	}

	public class ApplicationPrivilegesDescriptor : DescriptorPromiseBase<ApplicationPrivilegesDescriptor, IList<IApplicationPrivileges>>
	{
		public ApplicationPrivilegesDescriptor() : base(new List<IApplicationPrivileges>()) { }

		/// <summary>
		/// Adds an application privilege
		/// </summary>
		public ApplicationPrivilegesDescriptor Add<T>(Func<ApplicationPrivilegesDescriptor<T>, IApplicationPrivileges> selector) where T : class =>
			Assign(selector, (a, v) => a.AddIfNotNull(v?.Invoke(new ApplicationPrivilegesDescriptor<T>())));
	}


	// TODO this should not be generic, fix in NEST 7.x

	/// <inheritdoc cref="IApplicationPrivileges" />
	public class ApplicationPrivilegesDescriptor<T>
		: DescriptorBase<ApplicationPrivilegesDescriptor<T>, IApplicationPrivileges>, IApplicationPrivileges
		where T : class
	{
		/// <inheritdoc />
		string IApplicationPrivileges.Application { get; set; }

		/// <inheritdoc />
		IEnumerable<string> IApplicationPrivileges.Privileges { get; set; }

		/// <inheritdoc />
		IEnumerable<string> IApplicationPrivileges.Resources { get; set; }

		/// <inheritdoc cref="IApplicationPrivileges.Application" />
		public ApplicationPrivilegesDescriptor<T> Application(string application) => Assign(application, (a, v) => a.Application = v);

		/// <inheritdoc cref="IApplicationPrivileges.Privileges" />
		public ApplicationPrivilegesDescriptor<T> Privileges(params string[] privileges) => Assign(privileges, (a, v) => a.Privileges = v);

		/// <inheritdoc cref="IApplicationPrivileges.Privileges" />
		public ApplicationPrivilegesDescriptor<T> Privileges(IEnumerable<string> privileges) => Assign(privileges, (a, v) => a.Privileges = v);

		/// <inheritdoc cref="IApplicationPrivileges.Resources" />
		public ApplicationPrivilegesDescriptor<T> Resources(params string[] resources) => Assign(resources, (a, v) => a.Resources = v);

		/// <inheritdoc cref="IApplicationPrivileges.Resources" />
		public ApplicationPrivilegesDescriptor<T> Resources(IEnumerable<string> resources) => Assign(resources, (a, v) => a.Resources = v);
	}
}
