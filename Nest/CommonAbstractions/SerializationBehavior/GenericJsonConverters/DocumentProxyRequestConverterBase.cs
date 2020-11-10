using System;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using static Elasticsearch.Net.SerializationFormatting;

namespace Nest6
{
	internal abstract class DocumentProxyRequestConverterBase : JsonConverter
	{
		private readonly Type _genericRequestType;

		protected DocumentProxyRequestConverterBase(Type genericRequestType) =>
			_genericRequestType = genericRequestType;

		public override bool CanRead => true;
		public override bool CanWrite => true;

		public override bool CanConvert(Type objectType) => true;

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var token = reader.ReadTokenWithDateParseHandlingNone();
			using (var ms = token.ToStream(serializer.GetConnectionSettings().MemoryStreamFactory))
			{
				//not optimized but deserializing create requests is far from common practice
				var genericType = objectType.GetTypeInfo().GenericTypeArguments[0];
				var o = serializer.GetConnectionSettings().SourceSerializer.Deserialize(genericType, ms);
				var path = typeof(DocumentPath<>).CreateGenericInstance(genericType, o);
				// index, type and id are optional parameters on _genericRequestType but need to be passed to construct through reflection
				var x = _genericRequestType.CreateGenericInstance(genericType, path, null, null, null);
				return x;
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var untypedDocumentRequest = (IProxyRequest)value;
			var f = writer.Formatting == Formatting.Indented ? Indented : None;
			using (var ms = new MemoryStream())
			{
				untypedDocumentRequest.WriteJson(serializer.GetConnectionSettings().SourceSerializer, ms, f);
				var v = ms.TryGetBuffer(out ArraySegment<byte> buffer) && buffer.Array != null
					? Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count)
					: Encoding.UTF8.GetString(ms.ToArray());
				writer.WriteRawValue(v);
			}
		}
	}
}
