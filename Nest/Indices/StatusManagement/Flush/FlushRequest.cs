namespace Nest6
{
	public partial interface IFlushRequest { }

	public partial class FlushRequest { }

	[DescriptorFor("IndicesFlush")]
	public partial class FlushDescriptor { }
}
