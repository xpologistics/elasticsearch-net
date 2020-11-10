using Newtonsoft.Json;

namespace Nest6
{
	public interface IDeleteRoleResponse : IResponse
	{
		[JsonProperty("found")]
		bool Found { get; }
	}

	public class DeleteRoleResponse : ResponseBase, IDeleteRoleResponse
	{
		public bool Found { get; internal set; }
	}
}
