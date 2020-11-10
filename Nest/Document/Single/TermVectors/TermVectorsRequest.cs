﻿using System;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	public partial interface ITermVectorsRequest<TDocument>
		where TDocument : class
	{
		/// <summary>
		/// An optional document to get term vectors for instead of using an already indexed document
		/// </summary>
		[JsonProperty("doc")]
		[JsonConverter(typeof(SourceConverter))]
		TDocument Document { get; set; }

		/// <summary>
		/// Filter the terms returned based on their TF-IDF scores.
		/// This can be useful in order find out a good characteristic vector of a document.
		/// </summary>
		[JsonProperty("filter")]
		ITermVectorFilter Filter { get; set; }

		/// <summary>
		/// Provide a different analyzer than the one at the field.
		/// This is useful in order to generate term vectors in any fashion, especially when using artificial documents.
		/// </summary>
		[JsonProperty("per_field_analyzer")]
		IPerFieldAnalyzer PerFieldAnalyzer { get; set; }
	}

	public partial class TermVectorsRequest<TDocument>
		where TDocument : class
	{
		/// <summary>
		/// An optional document to get term vectors for instead of using an already indexed document
		/// </summary>
		public TDocument Document { get; set; }

		/// <summary>
		/// Filter the terms returned based on their TF-IDF scores.
		/// This can be useful in order find out a good characteristic vector of a document.
		/// </summary>
		public ITermVectorFilter Filter { get; set; }

		/// <summary>
		/// Provide a different analyzer than the one at the field.
		/// This is useful in order to generate term vectors in any fashion, especially when using artificial documents.
		/// </summary>
		public IPerFieldAnalyzer PerFieldAnalyzer { get; set; }

		HttpMethod IRequest.HttpMethod => Document != null || Filter != null ? HttpMethod.POST : HttpMethod.GET;

		private TDocument AutoRouteDocument() => Self.Document;

		partial void DocumentFromPath(TDocument document)
		{
			Self.Document = document;
			if (Self.Document != null)
				Self.RouteValues.Remove("id");
		}
	}

	[DescriptorFor("Termvectors")]
	public partial class TermVectorsDescriptor<TDocument> where TDocument : class
	{
		TDocument ITermVectorsRequest<TDocument>.Document { get; set; }

		ITermVectorFilter ITermVectorsRequest<TDocument>.Filter { get; set; }
		HttpMethod IRequest.HttpMethod => Self.Document != null || Self.Filter != null ? HttpMethod.POST : HttpMethod.GET;

		IPerFieldAnalyzer ITermVectorsRequest<TDocument>.PerFieldAnalyzer { get; set; }

		private TDocument AutoRouteDocument() => Self.Document;

		/// <summary>
		/// An optional document to get term vectors for instead of using an already indexed document
		/// </summary>
		public TermVectorsDescriptor<TDocument> Document(TDocument document) => Assign(document, (a, v) => a.Document = v);

		/// <summary>
		/// Provide a different analyzer than the one at the field.
		/// This is useful in order to generate term vectors in any fashion, especially when using artificial documents.
		/// </summary>
		public TermVectorsDescriptor<TDocument> PerFieldAnalyzer(
			Func<PerFieldAnalyzerDescriptor<TDocument>, IPromise<IPerFieldAnalyzer>> analyzerSelector
		) =>
			Assign(analyzerSelector, (a, v) => a.PerFieldAnalyzer = v?.Invoke(new PerFieldAnalyzerDescriptor<TDocument>())?.Value);

		/// <summary>
		/// Filter the terms returned based on their TF-IDF scores.
		/// This can be useful in order find out a good characteristic vector of a document.
		/// </summary>
		public TermVectorsDescriptor<TDocument> Filter(Func<TermVectorFilterDescriptor, ITermVectorFilter> filterSelector) =>
			Assign(filterSelector, (a, v) => a.Filter = v?.Invoke(new TermVectorFilterDescriptor()));
	}
}
