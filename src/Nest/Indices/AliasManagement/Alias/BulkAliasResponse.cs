namespace Nest6
{
	public interface IBulkAliasResponse : IAcknowledgedResponse { }

	public class BulkAliasResponse : AcknowledgedResponseBase, IBulkAliasResponse { }
}
