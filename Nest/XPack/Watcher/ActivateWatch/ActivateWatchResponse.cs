﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IActivateWatchResponse : IResponse
	{
		[JsonProperty("status")]
		ActivationStatus Status { get; }
	}

	public class ActivateWatchResponse : ResponseBase, IActivateWatchResponse
	{
		[JsonProperty("status")]
		public ActivationStatus Status { get; internal set; }
	}

	[JsonObject]
	public class ActivationStatus
	{
		[JsonProperty("actions")]
		public IReadOnlyDictionary<string, ActionStatus> Actions { get; set; }

		[JsonProperty("state")]
		public ActivationState State { get; internal set; }
	}
}
