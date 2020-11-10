﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary> The SQL Translate API accepts SQL in a JSON document and translates it into a native Elasticsearch search request</summary>
		ITranslateSqlResponse TranslateSql(Func<TranslateSqlDescriptor, ITranslateSqlRequest> selector = null);

		/// <inheritdoc cref="TranslateSql(System.Func{Nest6.TranslateSqlDescriptor,Nest6.ITranslateSqlRequest})" />
		ITranslateSqlResponse TranslateSql(ITranslateSqlRequest request);

		/// <inheritdoc cref="TranslateSql(System.Func{Nest6.TranslateSqlDescriptor,Nest6.ITranslateSqlRequest})" />
		Task<ITranslateSqlResponse> TranslateSqlAsync(Func<TranslateSqlDescriptor, ITranslateSqlRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="TranslateSql(System.Func{Nest6.TranslateSqlDescriptor,Nest6.ITranslateSqlRequest})" />
		Task<ITranslateSqlResponse> TranslateSqlAsync(ITranslateSqlRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="TranslateSql(System.Func{Nest6.TranslateSqlDescriptor,Nest6.ITranslateSqlRequest})" />
		public ITranslateSqlResponse TranslateSql(Func<TranslateSqlDescriptor, ITranslateSqlRequest> selector = null) =>
			TranslateSql(selector.InvokeOrDefault(new TranslateSqlDescriptor()));

		/// <inheritdoc cref="TranslateSql(System.Func{Nest6.TranslateSqlDescriptor,Nest6.ITranslateSqlRequest})" />
		public ITranslateSqlResponse TranslateSql(ITranslateSqlRequest request) =>
			Dispatcher.Dispatch<ITranslateSqlRequest, TranslateSqlRequestParameters, TranslateSqlResponse>(
				request,
				ToTranslateSqlResponse,
				(p, d) => LowLevelDispatch.XpackSqlTranslateDispatch<TranslateSqlResponse>(p, d)
			);

		/// <inheritdoc cref="TranslateSql(System.Func{Nest6.TranslateSqlDescriptor,Nest6.ITranslateSqlRequest})" />
		public Task<ITranslateSqlResponse> TranslateSqlAsync(Func<TranslateSqlDescriptor, ITranslateSqlRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			TranslateSqlAsync(selector.InvokeOrDefault(new TranslateSqlDescriptor()), cancellationToken);

		/// <inheritdoc cref="TranslateSql(System.Func{Nest6.TranslateSqlDescriptor,Nest6.ITranslateSqlRequest})" />
		public Task<ITranslateSqlResponse> TranslateSqlAsync(ITranslateSqlRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher.DispatchAsync<ITranslateSqlRequest, TranslateSqlRequestParameters, TranslateSqlResponse, ITranslateSqlResponse>(
				request,
				cancellationToken,
				ToTranslateSqlResponse,
				(p, d, c) => LowLevelDispatch.XpackSqlTranslateDispatchAsync<TranslateSqlResponse>(p, d, c)
			);

		private TranslateSqlResponse ToTranslateSqlResponse(IApiCallDetails apiCallDetails, Stream stream)
		{
			var result = RequestResponseSerializer.Deserialize<ISearchRequest>(stream);
			return new TranslateSqlResponse { Result = result };
		}
	}
}
