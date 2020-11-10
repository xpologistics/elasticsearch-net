﻿using Newtonsoft.Json;

namespace Nest6
{
	public interface IForecastJobResponse : IAcknowledgedResponse
	{
		[JsonProperty("forecast_id")]
		string ForecastId { get; }
	}

	public class ForecastJobResponse : AcknowledgedResponseBase, IForecastJobResponse
	{
		public string ForecastId { get; internal set; }
	}
}
