﻿namespace Nest6
{
	public partial interface IDeprecationInfoRequest { }

	public partial class DeprecationInfoRequest { }

	[DescriptorFor("XpackMigrationDeprecations")]
	public partial class DeprecationInfoDescriptor : IDeprecationInfoRequest { }
}
