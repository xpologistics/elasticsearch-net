﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		[Obsolete("Maintained for binary compatibility. Use the overload that accepts TaskId. Will be removed in 7.0")]
		IReindexRethrottleResponse Rethrottle(Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector);

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		IReindexRethrottleResponse Rethrottle(TaskId id, Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector = null);

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		IReindexRethrottleResponse Rethrottle(IReindexRethrottleRequest request);

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		[Obsolete("Maintained for binary compatibility. Use the overload that accepts TaskId. Will be removed in 7.0")]
		Task<IReindexRethrottleResponse> RethrottleAsync(Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		Task<IReindexRethrottleResponse> RethrottleAsync(TaskId id, Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		Task<IReindexRethrottleResponse> RethrottleAsync(IReindexRethrottleRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		[Obsolete("Maintained for binary compatibility. Use the overload that accepts TaskId. Will be removed in 7.0")]
		public IReindexRethrottleResponse Rethrottle(Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector) =>
#pragma warning disable 618 // changing method signature would be binary breaking
			Rethrottle(selector.InvokeOrDefault(new ReindexRethrottleDescriptor()));
#pragma warning restore 618

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		public IReindexRethrottleResponse Rethrottle(TaskId id, Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector = null) =>
			Rethrottle(selector.InvokeOrDefault(new ReindexRethrottleDescriptor(id)));

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		public IReindexRethrottleResponse Rethrottle(IReindexRethrottleRequest request) =>
			Dispatcher.Dispatch<IReindexRethrottleRequest, ReindexRethrottleRequestParameters, ReindexRethrottleResponse>(
				request,
				(p, d) => LowLevelDispatch.ReindexRethrottleDispatch<ReindexRethrottleResponse>(p)
			);

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		[Obsolete("Maintained for binary compatibility. Use the overload that accepts TaskId. Will be removed in 7.0")]
		public Task<IReindexRethrottleResponse> RethrottleAsync(Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
#pragma warning disable 618 // changing method signature would be binary breaking
			RethrottleAsync(selector.InvokeOrDefault(new ReindexRethrottleDescriptor()), cancellationToken);
#pragma warning restore 618

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		public Task<IReindexRethrottleResponse> RethrottleAsync(TaskId id,
			Func<ReindexRethrottleDescriptor, IReindexRethrottleRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			RethrottleAsync(selector.InvokeOrDefault(new ReindexRethrottleDescriptor(id)), cancellationToken);

		/// <summary>
		/// Rethrottle an existing reindex or update by query task
		/// </summary>
		public Task<IReindexRethrottleResponse> RethrottleAsync(IReindexRethrottleRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher
				.DispatchAsync<IReindexRethrottleRequest, ReindexRethrottleRequestParameters, ReindexRethrottleResponse, IReindexRethrottleResponse>(
					request,
					cancellationToken,
					(p, d, c) => LowLevelDispatch.ReindexRethrottleDispatchAsync<ReindexRethrottleResponse>(p, c)
				);
	}
}
