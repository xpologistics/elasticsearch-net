﻿namespace Nest6
{
	public partial interface IXPackUsageRequest { }

	public partial class XPackUsageRequest { }

	[DescriptorFor("XpackUsage")]
	public partial class XPackUsageDescriptor : IXPackUsageRequest { }
}
