﻿using System.Collections.Generic;

namespace Nest6
{
	public partial interface IIndicesStatsRequest
	{
		IEnumerable<TypeName> Types { get; set; }
	}

	public partial class IndicesStatsRequest
	{
		private IEnumerable<TypeName> _types;

		public IEnumerable<TypeName> Types
		{
			get => _types;
			set
			{
				RequestState.RequestParameters.SetQueryString("types", value.HasAny() ? value : null);
				_types = value;
			}
		}
	}

	[DescriptorFor("IndicesStats")]
	public partial class IndicesStatsDescriptor
	{
		private IEnumerable<TypeName> _types;

		IEnumerable<TypeName> IIndicesStatsRequest.Types
		{
			get => _types;
			set
			{
				RequestState.RequestParameters.SetQueryString("types", value.HasAny() ? value : null);
				_types = value;
			}
		}

		//<summary>A comma-separated list of fields for `completion` metric (supports wildcards)</summary>
		public IndicesStatsDescriptor Types(params TypeName[] types) =>
			Assign(types, (a, v) => a.Types = v);
	}
}
