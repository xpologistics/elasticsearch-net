using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Updates the description of a machine learning filter, adds items, or removes items.
	/// </summary>
	public partial interface IUpdateFilterRequest
	{
		/// <summary>
		/// A description for the filter
		/// </summary>
		[JsonProperty("description")]
		string Description { get; set; }

		/// <summary>
		/// The items to add to the filter
		/// </summary>
		[JsonProperty("add_items")]
		IEnumerable<string> AddItems { get; set; }

		/// <summary>
		/// The items to remove from the filter
		/// </summary>
		[JsonProperty("remove_items")]
		IEnumerable<string> RemoveItems { get; set; }
	}

	/// <inheritdoc cref="UpdateFilterRequest" />
	public partial class UpdateFilterRequest : IUpdateFilterRequest
	{
		/// <inheritdoc />
		public string Description { get; set; }

		/// <inheritdoc />
		public IEnumerable<string> AddItems { get; set; }

		/// <inheritdoc />
		public IEnumerable<string> RemoveItems { get; set; }
	}

	[DescriptorFor("XpackMlUpdateFilter")]
	public partial class UpdateFilterDescriptor : IUpdateFilterRequest
	{
		string IUpdateFilterRequest.Description { get; set; }
		IEnumerable<string> IUpdateFilterRequest.AddItems { get; set; }
		IEnumerable<string> IUpdateFilterRequest.RemoveItems { get; set; }

		/// <inheritdoc cref="IUpdateFilterRequest.Description" />
		public UpdateFilterDescriptor Description(string description) => Assign(description, (a, v) => a.Description = v);

		/// <inheritdoc cref="IUpdateFilterRequest.AddItems" />
		public UpdateFilterDescriptor AddItems(params string[] items) => Assign(items, (a, v) => a.AddItems = v);

		/// <inheritdoc cref="IUpdateFilterRequest.AddItems" />
		public UpdateFilterDescriptor AddItems(IEnumerable<string> items) => Assign(items, (a, v) => a.AddItems = v);

		/// <inheritdoc cref="IUpdateFilterRequest.RemoveItems" />
		public UpdateFilterDescriptor RemoveItems(params string[] items) => Assign(items, (a, v) => a.RemoveItems = v);

		/// <inheritdoc cref="IUpdateFilterRequest.RemoveItems" />
		public UpdateFilterDescriptor RemoveItems(IEnumerable<string> items) => Assign(items, (a, v) => a.RemoveItems = v);
	}
}
