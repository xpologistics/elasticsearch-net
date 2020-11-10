﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Clear a cursor returned by <see cref="IQuerySqlResponse.Cursor" />. Not that this is only necessary if you wish to bail out early
		/// </summary>
		IClearSqlCursorResponse ClearSqlCursor(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest6.ClearSqlCursorDescriptor,Nest6.IClearSqlCursorRequest})" />
		IClearSqlCursorResponse ClearSqlCursor(IClearSqlCursorRequest request);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest6.ClearSqlCursorDescriptor,Nest6.IClearSqlCursorRequest})" />
		Task<IClearSqlCursorResponse> ClearSqlCursorAsync(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest6.ClearSqlCursorDescriptor,Nest6.IClearSqlCursorRequest})" />
		Task<IClearSqlCursorResponse> ClearSqlCursorAsync(IClearSqlCursorRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest6.ClearSqlCursorDescriptor,Nest6.IClearSqlCursorRequest})" />
		public IClearSqlCursorResponse ClearSqlCursor(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null) =>
			ClearSqlCursor(selector.InvokeOrDefault(new ClearSqlCursorDescriptor()));

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest6.ClearSqlCursorDescriptor,Nest6.IClearSqlCursorRequest})" />
		public IClearSqlCursorResponse ClearSqlCursor(IClearSqlCursorRequest request) =>
			Dispatcher.Dispatch<IClearSqlCursorRequest, ClearSqlCursorRequestParameters, ClearSqlCursorResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackSqlClearCursorDispatch<ClearSqlCursorResponse>(p, d)
			);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest6.ClearSqlCursorDescriptor,Nest6.IClearSqlCursorRequest})" />
		public Task<IClearSqlCursorResponse> ClearSqlCursorAsync(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			ClearSqlCursorAsync(selector.InvokeOrDefault(new ClearSqlCursorDescriptor()), cancellationToken);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest6.ClearSqlCursorDescriptor,Nest6.IClearSqlCursorRequest})" />
		public Task<IClearSqlCursorResponse> ClearSqlCursorAsync(IClearSqlCursorRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher.DispatchAsync<IClearSqlCursorRequest, ClearSqlCursorRequestParameters, ClearSqlCursorResponse, IClearSqlCursorResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackSqlClearCursorDispatchAsync<ClearSqlCursorResponse>(p, d, c)
			);
	}
}
