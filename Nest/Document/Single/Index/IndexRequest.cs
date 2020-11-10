﻿using System.IO;
using Elasticsearch.Net;

namespace Nest6
{
	[ContractJsonConverter(typeof(IndexJsonConverter))]
	public partial interface IIndexRequest<TDocument> : IProxyRequest where TDocument : class
	{
		TDocument Document { get; set; }
	}

	public partial class IndexRequest<TDocument>
		where TDocument : class
	{
		public TDocument Document { get; set; }

		protected override HttpMethod HttpMethod => GetHttpMethod(this);

		void IProxyRequest.WriteJson(IElasticsearchSerializer sourceSerializer, Stream stream, SerializationFormatting formatting) =>
			sourceSerializer.Serialize(Document, stream, formatting);

		protected void DefaultRouting() => Self.RequestParameters.SetQueryString("routing", new Routing(() => Document));

		internal static HttpMethod GetHttpMethod(IIndexRequest<TDocument> request) =>
			request.Id?.StringOrLongValue != null || request.RouteValues.Id != null ? HttpMethod.PUT : HttpMethod.POST;

		partial void DocumentFromPath(TDocument document) => Document = document;

		private TDocument AutoRouteDocument() => Self.Document;
	}

	public partial class IndexDescriptor<TDocument> where TDocument : class
	{
		protected override HttpMethod HttpMethod => IndexRequest<TDocument>.GetHttpMethod(this);
		TDocument IIndexRequest<TDocument>.Document { get; set; }

		void IProxyRequest.WriteJson(IElasticsearchSerializer sourceSerializer, Stream stream, SerializationFormatting formatting) =>
			sourceSerializer.Serialize(Self.Document, stream, formatting);

		partial void DocumentFromPath(TDocument document) => Assign(document, (a, v) => a.Document = v);

		private TDocument AutoRouteDocument() => Self.Document;
	}
}
