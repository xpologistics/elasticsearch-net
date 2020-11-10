﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization.OptIn)]
	public interface IShrinkIndexResponse : IAcknowledgedResponse
	{
		[JsonProperty("shards_acknowledged")]
		bool ShardsAcknowledged { get; }
	}

	public class ShrinkIndexResponse : AcknowledgedResponseBase, IShrinkIndexResponse
	{
		public bool ShardsAcknowledged { get; internal set; }
	}
}
