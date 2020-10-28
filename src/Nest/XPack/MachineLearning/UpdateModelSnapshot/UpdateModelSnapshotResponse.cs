using Newtonsoft.Json;

namespace Nest6
{
	public interface IUpdateModelSnapshotResponse : IAcknowledgedResponse
	{
		[JsonProperty("model")]
		ModelSnapshot Model { get; }
	}

	public class UpdateModelSnapshotResponse : AcknowledgedResponseBase, IUpdateModelSnapshotResponse
	{
		public ModelSnapshot Model { get; internal set; }
	}
}
