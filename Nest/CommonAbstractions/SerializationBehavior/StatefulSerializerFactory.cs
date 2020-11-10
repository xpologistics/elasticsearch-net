using Newtonsoft.Json;

namespace Nest6
{
	internal static class StatefulSerializerFactory
	{
		public static InternalSerializer CreateStateful(IConnectionSettingsValues settings, JsonConverter converter) =>
			new InternalSerializer(settings, converter);
	}
}
