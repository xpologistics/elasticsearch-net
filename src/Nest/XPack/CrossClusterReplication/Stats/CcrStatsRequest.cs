using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Gets cross-cluster replication stats. Returns all stats related to cross-cluster replication.
	/// In particular, this API returns stats about auto-following, and returns the same shard-level stats as in the get
	/// follower stats API. <see cref="IElasticClient.FollowIndexStats(Nest6.Indices,System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})"/>
	/// </summary>
	[MapsApi("ccr.stats.json")]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<CcrStatsRequest>))]
	public partial interface ICcrStatsRequest { }

	/// <inheritdoc cref="ICcrStatsRequest"/>
	public partial class CcrStatsRequest { }

	/// <inheritdoc cref="ICcrStatsRequest"/>
	public partial class CcrStatsDescriptor { }
}
