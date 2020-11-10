﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<PutWatchResponse>))]
	public interface IPutWatchResponse : IResponse
	{
		[JsonProperty("created")]
		bool Created { get; }

		[JsonProperty("_id")]
		string Id { get; }

		[JsonProperty("_version")]
		int Version { get; }
	}

	public class PutWatchResponse : ResponseBase, IPutWatchResponse
	{
		public bool Created { get; internal set; }
		public string Id { get; internal set; }

		public int Version { get; internal set; }
	}
}
