﻿using System;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IExplainRequest<TDocument> where TDocument : class
	{
		[JsonProperty("query")]
		QueryContainer Query { get; set; }
	}

	public partial class ExplainRequest<TDocument> : IExplainRequest<TDocument>
		where TDocument : class
	{
		public QueryContainer Query { get; set; }

		public Fields StoredFields { get; set; }

		protected override HttpMethod HttpMethod =>
			RequestState.RequestParameters?.ContainsQueryString("source") == true || RequestState.RequestParameters?.ContainsQueryString("q") == true
				? HttpMethod.GET
				: HttpMethod.POST;

		private object AutoRouteDocument() => null;
	}

	[DescriptorFor("Explain")]
	public partial class ExplainDescriptor<TDocument> : IExplainRequest<TDocument>
		where TDocument : class
	{
		protected override HttpMethod HttpMethod =>
			RequestState.RequestParameters?.ContainsQueryString("source") == true || RequestState.RequestParameters?.ContainsQueryString("q") == true
				? HttpMethod.GET
				: HttpMethod.POST;

		QueryContainer IExplainRequest<TDocument>.Query { get; set; }

		Fields IExplainRequest<TDocument>.StoredFields { get; set; }

		private object AutoRouteDocument() => null;

		public ExplainDescriptor<TDocument> Query(Func<QueryContainerDescriptor<TDocument>, QueryContainer> querySelector) =>
			Assign(querySelector, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<TDocument>()));

		/// <summary>
		/// Allows to selectively load specific fields for each document
		/// represented by a search hit. Defaults to load the internal _source field.
		/// </summary>
		public ExplainDescriptor<TDocument> StoredFields(Func<FieldsDescriptor<TDocument>, IPromise<Fields>> fields) =>
			Assign(fields, (a, v) => a.StoredFields = v?.Invoke(new FieldsDescriptor<TDocument>())?.Value);

		public ExplainDescriptor<TDocument> StoredFields(Fields fields) => Assign(fields, (a, v) => a.StoredFields = v);
	}
}
