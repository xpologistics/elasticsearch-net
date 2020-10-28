using Newtonsoft.Json;

namespace Nest6
{
	[ContractJsonConverter(typeof(ClusterRerouteCommandJsonConverter))]
	public interface IClusterRerouteCommand
	{
		[JsonIgnore]
		string Name { get; }
	}
}
