﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface INodesInfoResponse : INodesResponse
	{
		string ClusterName { get; }
		IReadOnlyDictionary<string, NodeInfo> Nodes { get; }
	}

	[JsonObject]
	public class NodesInfoResponse : NodesResponseBase, INodesInfoResponse
	{
		[JsonProperty("cluster_name")]
		public string ClusterName { get; internal set; }

		[JsonProperty("nodes")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, NodeInfo>))]
		public IReadOnlyDictionary<string, NodeInfo> Nodes { get; internal set; } = EmptyReadOnly<string, NodeInfo>.Dictionary;
	}
}
