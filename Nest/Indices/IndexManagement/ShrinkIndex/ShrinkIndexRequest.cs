﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<ShrinkIndexRequest>))]
	public partial interface IShrinkIndexRequest
	{
		[JsonProperty("aliases")]
		IAliases Aliases { get; set; }

		[JsonProperty("settings")]
		IIndexSettings Settings { get; set; }
	}

	public partial class ShrinkIndexRequest
	{
		// For ReadAsType()
		internal ShrinkIndexRequest() { }

		public IAliases Aliases { get; set; }

		public IIndexSettings Settings { get; set; }
	}

	[DescriptorFor("IndicesShrink")]
	public partial class ShrinkIndexDescriptor
	{
		IAliases IShrinkIndexRequest.Aliases { get; set; }
		IIndexSettings IShrinkIndexRequest.Settings { get; set; }

		public ShrinkIndexDescriptor Settings(Func<IndexSettingsDescriptor, IPromise<IIndexSettings>> selector) =>
			Assign(selector, (a, v) => a.Settings = v?.Invoke(new IndexSettingsDescriptor())?.Value);

		public ShrinkIndexDescriptor Aliases(Func<AliasesDescriptor, IPromise<IAliases>> selector) =>
			Assign(selector, (a, v) => a.Aliases = v?.Invoke(new AliasesDescriptor())?.Value);
	}
}
