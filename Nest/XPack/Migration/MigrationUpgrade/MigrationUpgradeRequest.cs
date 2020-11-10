namespace Nest6
{
	public partial interface IMigrationUpgradeRequest { }

	public partial class MigrationUpgradeRequest { }

	[DescriptorFor("XpackMigrationUpgrade")]
	public partial class MigrationUpgradeDescriptor : IMigrationUpgradeRequest { }
}
