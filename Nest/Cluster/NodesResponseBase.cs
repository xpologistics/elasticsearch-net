﻿using Newtonsoft.Json;

namespace Nest6
{
	public abstract class NodesResponseBase : ResponseBase, INodesResponse
	{
		public NodeStatistics NodeStatistics { get; internal set; }
	}

	public interface INodesResponse : IResponse
	{
		[JsonProperty("_nodes")]
		NodeStatistics NodeStatistics { get; }
	}

	[JsonObject]
	public class NodeStatistics
	{
		[JsonProperty]
		public int Failed { get; internal set; }

		[JsonProperty]
		public int Successful { get; internal set; }

		[JsonProperty]
		public int Total { get; internal set; }

		//TODO map failures
	}
}
