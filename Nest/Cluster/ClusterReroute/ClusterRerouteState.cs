﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class ClusterRerouteState
	{
		[JsonProperty("blocks")]
		public BlockState Blocks { get; internal set; }

		[JsonProperty("master_node")]
		public string MasterNode { get; internal set; }

		[JsonProperty("nodes")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, NodeState>))]
		public IReadOnlyDictionary<string, NodeState> Nodes { get; internal set; }

		[JsonProperty("routing_nodes")]
		public RoutingNodesState RoutingNodes { get; internal set; }

		[JsonProperty("routing_table")]
		public RoutingTableState RoutingTable { get; internal set; }

		[JsonProperty("version")]
		public int Version { get; internal set; }
	}
}
