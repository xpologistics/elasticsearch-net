using Newtonsoft.Json;

namespace Nest6
{
	public interface IDeleteRoleMappingResponse : IResponse
	{
		[JsonProperty("found")]
		bool Found { get; }
	}

	public class DeleteRoleMappingResponse : ResponseBase, IDeleteRoleMappingResponse
	{
		public bool Found { get; internal set; }
	}
}
