﻿using System.IO;
using Elasticsearch.Net;

namespace Nest6
{
	[ContractJsonConverter(typeof(CreateJsonConverter))]
	public partial interface ICreateRequest<TDocument> : IProxyRequest where TDocument : class
	{
		TDocument Document { get; set; }
	}

	public partial class CreateRequest<TDocument> where TDocument : class
	{
		public TDocument Document { get; set; }

		void IProxyRequest.WriteJson(IElasticsearchSerializer sourceSerializer, Stream stream, SerializationFormatting formatting) =>
			sourceSerializer.Serialize(Document, stream, formatting);

		partial void DocumentFromPath(TDocument document) => Document = document;

		private TDocument AutoRouteDocument() => Document;
	}

	[DescriptorFor("Create")]
	public partial class CreateDescriptor<TDocument> where TDocument : class
	{
		TDocument ICreateRequest<TDocument>.Document { get; set; }

		void IProxyRequest.WriteJson(IElasticsearchSerializer sourceSerializer, Stream stream, SerializationFormatting formatting) =>
			sourceSerializer.Serialize(Self.Document, stream, formatting);

		partial void DocumentFromPath(TDocument document) => Assign(document, (a, v) => a.Document = v);

		private TDocument AutoRouteDocument() => Self.Document;

		/// <summary>
		/// Sets the id for the document. Overrides the id that may be inferred from the document.
		/// </summary>
		public CreateDescriptor<TDocument> Id(Id id) => Assign(id,(a,v) => a.RouteValues.Required("id", v));
	}
}
