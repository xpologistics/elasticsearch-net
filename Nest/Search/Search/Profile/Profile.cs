using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public class Profile
	{
		[JsonProperty("shards")]
		public IReadOnlyCollection<ShardProfile> Shards { get; internal set; } =
			EmptyReadOnly<ShardProfile>.Collection;
	}
}
