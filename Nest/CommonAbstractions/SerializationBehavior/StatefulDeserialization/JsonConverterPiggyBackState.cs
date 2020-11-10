using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Registering global JsonConverter is very costly,
	/// The best thing is to specify them as a contract (see ElasticContractResolver)
	/// This however prevents a way to give a JsonConverter state which for some calls is needed i.e:
	/// A multiget and multisearch need access to the descriptor that describes what types are used.
	/// When NEST knows it has to piggyback this it has to pass serialization state it will create a new
	/// serializersettings object with a new contract resolver which holds this state. Its ugly but it does boost
	/// massive performance gains.
	/// </summary>
	internal class JsonConverterPiggyBackState
	{
		public JsonConverter ActualJsonConverter { get; set; }
	}
}
