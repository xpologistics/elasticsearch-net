using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IGetRollupJobResponse : IResponse
	{
		[JsonProperty("jobs")]
		IReadOnlyCollection<RollupJobInformation> Jobs { get; }
	}

	public class GetRollupJobResponse : ResponseBase, IGetRollupJobResponse
	{
		public IReadOnlyCollection<RollupJobInformation> Jobs { get; internal set; } = EmptyReadOnly<RollupJobInformation>.Collection;
	}
}
