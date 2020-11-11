using Elasticsearch6.Net;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class BulkIndexByScrollFailure
	{
		[JsonProperty("cause")]
		public BulkIndexFailureCause Cause { get; set; }

		[JsonProperty("id")]
		public string Id { get; internal set; }

		[JsonProperty("index")]
		public string Index { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("type")]
		public string Type { get; internal set; }
	}

	[JsonObject]
	[ContractJsonConverter(typeof(ErrorCauseJsonConverter<BulkIndexFailureCause>))]
	public class BulkIndexFailureCause : Error
	{
		public string Index => Metadata?.Index;
		public string IndexUniqueId => Metadata?.IndexUUID;
		public int? Shard => Metadata?.Shard;
	}
}
