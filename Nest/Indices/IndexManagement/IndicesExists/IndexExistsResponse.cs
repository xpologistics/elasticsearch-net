﻿using Newtonsoft.Json;

namespace Nest6
{
	public interface IExistsResponse : IResponse
	{
		bool Exists { get; }
	}

	[JsonObject]
	public class ExistsResponse : ResponseBase, IExistsResponse
	{
		public bool Exists => ApiCall != null && ApiCall.Success && ApiCall.HttpStatusCode == 200;
	}
}
