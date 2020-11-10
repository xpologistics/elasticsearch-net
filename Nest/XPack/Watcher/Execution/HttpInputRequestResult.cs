using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[ExactContractJsonConverter(typeof(ReadAsTypeJsonConverter<HttpInputRequestResult>))]
	public class HttpInputRequestResult : HttpInputRequest { }
}
