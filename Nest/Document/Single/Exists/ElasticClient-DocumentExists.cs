﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	using ExistConverter = Func<IApiCallDetails, Stream, ExistsResponse>;

	public partial interface IElasticClient
	{
		/// <summary>
		/// Check if a document exists without returning its contents
		/// <para> </para>
		/// <a href="http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/docs-get.html">http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/docs-get.html</a>
		/// </summary>
		/// <typeparam name="T">The type used to infer the default index and typename</typeparam>
		/// <param name="selector">Describe what document we are looking for</param>
		IExistsResponse DocumentExists<T>(DocumentPath<T> document, Func<DocumentExistsDescriptor<T>, IDocumentExistsRequest> selector = null)
			where T : class;

		/// <inheritdoc />
		IExistsResponse DocumentExists(IDocumentExistsRequest request);

		/// <inheritdoc />
		Task<IExistsResponse> DocumentExistsAsync<T>(DocumentPath<T> document,
			Func<DocumentExistsDescriptor<T>, IDocumentExistsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		)
			where T : class;

		/// <inheritdoc />
		Task<IExistsResponse> DocumentExistsAsync(IDocumentExistsRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IExistsResponse DocumentExists<T>(DocumentPath<T> document, Func<DocumentExistsDescriptor<T>, IDocumentExistsRequest> selector = null)
			where T : class =>
			DocumentExists(selector.InvokeOrDefault(new DocumentExistsDescriptor<T>(document.Self.Index, document.Self.Type, document.Self.Id)));

		/// <inheritdoc />
		public IExistsResponse DocumentExists(IDocumentExistsRequest request) =>
			Dispatcher.Dispatch<IDocumentExistsRequest, DocumentExistsRequestParameters, ExistsResponse>(
				request,
				(p, d) => LowLevelDispatch.ExistsDispatch<ExistsResponse>(p)
			);

		/// <inheritdoc />
		public Task<IExistsResponse> DocumentExistsAsync<T>(DocumentPath<T> document,
			Func<DocumentExistsDescriptor<T>, IDocumentExistsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) where T : class =>
			DocumentExistsAsync(selector.InvokeOrDefault(new DocumentExistsDescriptor<T>(document.Self.Index, document.Self.Type, document.Self.Id)),
				cancellationToken);

		/// <inheritdoc />
		public Task<IExistsResponse> DocumentExistsAsync(IDocumentExistsRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher.DispatchAsync<IDocumentExistsRequest, DocumentExistsRequestParameters, ExistsResponse, IExistsResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.ExistsDispatchAsync<ExistsResponse>(p, c)
			);
	}
}
