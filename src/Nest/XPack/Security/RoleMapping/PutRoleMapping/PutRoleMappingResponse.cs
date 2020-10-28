using Newtonsoft.Json;

namespace Nest6
{
	public interface IPutRoleMappingResponse : IResponse
	{
		[JsonProperty("role_mapping")]
		PutRoleMappingStatus RoleMapping { get; }
	}

	public class PutRoleMappingResponse : ResponseBase, IPutRoleMappingResponse
	{
		public bool Created => RoleMapping?.Created ?? false;
		public PutRoleMappingStatus RoleMapping { get; internal set; }
	}

	public class PutRoleMappingStatus
	{
		[JsonProperty("created")]
		public bool Created { get; set; }
	}
}
