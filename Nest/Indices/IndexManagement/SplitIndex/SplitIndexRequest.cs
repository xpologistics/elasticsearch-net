﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A request to split an existing index into a new index, where each original primary
	/// shard is split into two or more primary shards in the new index.
	/// </summary>
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SplitIndexRequest>))]
	public partial interface ISplitIndexRequest
	{
		/// <summary>
		/// The aliases for the target index
		/// </summary>
		[JsonProperty("aliases")]
		IAliases Aliases { get; set; }

		/// <summary>
		/// The settings for the target index
		/// </summary>
		[JsonProperty("settings")]
		IIndexSettings Settings { get; set; }
	}

	/// <inheritdoc cref="ISplitIndexRequest" />
	public partial class SplitIndexRequest
	{
		// For ReadAsType()
		internal SplitIndexRequest() { }

		/// <inheritdoc />
		public IAliases Aliases { get; set; }

		/// <inheritdoc />
		public IIndexSettings Settings { get; set; }
	}

	/// <inheritdoc cref="ISplitIndexRequest" />
	[DescriptorFor("IndicesSplit")]
	public partial class SplitIndexDescriptor
	{
		IAliases ISplitIndexRequest.Aliases { get; set; }
		IIndexSettings ISplitIndexRequest.Settings { get; set; }

		/// <inheritdoc cref="ISplitIndexRequest.Settings" />
		public SplitIndexDescriptor Settings(Func<IndexSettingsDescriptor, IPromise<IIndexSettings>> selector) =>
			Assign(selector, (a, v) => a.Settings = v?.Invoke(new IndexSettingsDescriptor())?.Value);

		/// <inheritdoc cref="ISplitIndexRequest.Aliases" />
		public SplitIndexDescriptor Aliases(Func<AliasesDescriptor, IPromise<IAliases>> selector) =>
			Assign(selector, (a, v) => a.Aliases = v?.Invoke(new AliasesDescriptor())?.Value);
	}
}
