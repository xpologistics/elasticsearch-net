using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<ClusterAllocationExplainRequest>))]
	public partial interface IClusterAllocationExplainRequest
	{
		/// <summary>
		/// The name of the index to provide an explanation for
		/// </summary>
		[JsonProperty("index")]
		IndexName Index { get; set; }

		/// <summary>
		/// Whether to explain a primary or replica shard
		/// </summary>
		[JsonProperty("primary")]
		bool? Primary { get; set; }

		/// <summary>
		/// The shard id to provide an explanation for
		/// </summary>
		[JsonProperty("shard")]
		int? Shard { get; set; }
	}

	public partial class ClusterAllocationExplainRequest
	{
		/// <summary>
		/// The name of the index to provide an explanation for
		/// </summary>
		public IndexName Index { get; set; }

		/// <summary>
		/// Whether to explain a primary or replica shard
		/// </summary>
		public bool? Primary { get; set; }

		/// <summary>
		/// The shard id to provide an explanation for
		/// </summary>
		public int? Shard { get; set; }
	}

	public partial class ClusterAllocationExplainDescriptor
	{
		IndexName IClusterAllocationExplainRequest.Index { get; set; }
		bool? IClusterAllocationExplainRequest.Primary { get; set; }
		int? IClusterAllocationExplainRequest.Shard { get; set; }

		/// <summary>
		/// The name of the index to provide an explanation for
		/// </summary>
		public ClusterAllocationExplainDescriptor Index(IndexName index) => Assign(index, (a, v) => a.Index = v);

		/// <summary>
		/// The name of the index to provide an explanation for
		/// </summary>
		public ClusterAllocationExplainDescriptor Index<TDocument>() => Assign(typeof(TDocument), (a, v) => a.Index = v);

		/// <summary>
		/// Whether to explain a primary or replica shard
		/// </summary>
		public ClusterAllocationExplainDescriptor Primary(bool? primary = true) => Assign(primary, (a, v) => a.Primary = v);

		/// <summary>
		/// The shard id to provide an explanation for
		/// </summary>
		public ClusterAllocationExplainDescriptor Shard(int? shard) => Assign(shard, (a, v) => a.Shard = v);
	}
}
