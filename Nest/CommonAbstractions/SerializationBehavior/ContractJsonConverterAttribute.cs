using System;
using Newtonsoft.Json;

namespace Nest6
{
	internal class ContractJsonConverterAttribute : Attribute
	{
		public ContractJsonConverterAttribute(Type jsonConverter)
		{
			if (typeof(JsonConverter).IsAssignableFrom(jsonConverter)) Converter = jsonConverter.CreateInstance<JsonConverter>();
		}

		public JsonConverter Converter { get; }
	}

	internal class ExactContractJsonConverterAttribute : Attribute
	{
		public ExactContractJsonConverterAttribute(Type jsonConverter)
		{
			if (typeof(JsonConverter).IsAssignableFrom(jsonConverter)) Converter = jsonConverter.CreateInstance<JsonConverter>();
		}

		public JsonConverter Converter { get; }
	}
}
