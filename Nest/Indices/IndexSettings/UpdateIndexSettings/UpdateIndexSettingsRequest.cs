﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(IndexSettingsConverter))]
	public partial interface IUpdateIndexSettingsRequest
	{
		IDynamicIndexSettings IndexSettings { get; set; }
	}

	public partial class UpdateIndexSettingsRequest
	{
		public IDynamicIndexSettings IndexSettings { get; set; }
	}

	[DescriptorFor("IndicesPutSettings")]
	public partial class UpdateIndexSettingsDescriptor
	{
		IDynamicIndexSettings IUpdateIndexSettingsRequest.IndexSettings { get; set; }

		/// <inheritdoc />
		public UpdateIndexSettingsDescriptor IndexSettings(Func<DynamicIndexSettingsDescriptor, IPromise<IDynamicIndexSettings>> settings) =>
			Assign(settings, (a, v) => a.IndexSettings = v?.Invoke(new DynamicIndexSettingsDescriptor())?.Value);
	}
}
