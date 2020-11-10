﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface IStopRollupJobResponse : IResponse
	{
		[JsonProperty("stopped")]
		bool Stopped { get; set; }
	}

	public class StopRollupJobResponse : ResponseBase, IStopRollupJobResponse
	{
		public bool Stopped { get; set; }
	}
}
