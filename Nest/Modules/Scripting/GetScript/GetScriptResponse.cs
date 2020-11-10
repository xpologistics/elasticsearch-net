﻿using Newtonsoft.Json;

namespace Nest6
{
	public interface IGetScriptResponse : IResponse
	{
		IStoredScript Script { get; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class GetScriptResponse : ResponseBase, IGetScriptResponse
	{
		[JsonProperty("script")]
		public IStoredScript Script { get; set; }
	}
}
