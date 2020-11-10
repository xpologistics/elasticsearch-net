﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Stops the following task associated with a follower index and removes index metadata and settings associated with
		/// cross-cluster replication. This enables the index to treated as a regular index. The follower index must be paused and closed
		/// before invoking the unfollow API.
		/// </summary>
		IUnfollowIndexResponse UnfollowIndex(IndexName index, Func<UnfollowIndexDescriptor, IUnfollowIndexRequest> selector = null);

		/// <inheritdoc cref="UnfollowIndex(IndexName, System.Func{Nest6.UnfollowIndexDescriptor,Nest6.IUnfollowIndexRequest})" />
		IUnfollowIndexResponse UnfollowIndex(IUnfollowIndexRequest request);

		/// <inheritdoc cref="UnfollowIndex(IndexName, System.Func{Nest6.UnfollowIndexDescriptor,Nest6.IUnfollowIndexRequest})" />
		Task<IUnfollowIndexResponse> UnfollowIndexAsync(IndexName index, Func<UnfollowIndexDescriptor, IUnfollowIndexRequest> selector = null,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc cref="UnfollowIndex(IndexName, System.Func{Nest6.UnfollowIndexDescriptor,Nest6.IUnfollowIndexRequest})" />
		Task<IUnfollowIndexResponse> UnfollowIndexAsync(IUnfollowIndexRequest request, CancellationToken cancellationToken = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="UnfollowIndex(IndexName, System.Func{Nest6.UnfollowIndexDescriptor,Nest6.IUnfollowIndexRequest})" />
		public IUnfollowIndexResponse UnfollowIndex(IndexName index, Func<UnfollowIndexDescriptor, IUnfollowIndexRequest> selector = null) =>
			UnfollowIndex(selector.InvokeOrDefault(new UnfollowIndexDescriptor(index)));

		/// <inheritdoc cref="UnfollowIndex(IndexName, System.Func{Nest6.UnfollowIndexDescriptor,Nest6.IUnfollowIndexRequest})" />
		public IUnfollowIndexResponse UnfollowIndex(IUnfollowIndexRequest request) =>
			Dispatcher.Dispatch<IUnfollowIndexRequest, UnfollowIndexRequestParameters, UnfollowIndexResponse>(
				request,
				(p, d) => LowLevelDispatch.CcrUnfollowDispatch<UnfollowIndexResponse>(p)
			);

		/// <inheritdoc cref="UnfollowIndex(IndexName, System.Func{Nest6.UnfollowIndexDescriptor,Nest6.IUnfollowIndexRequest})" />
		public Task<IUnfollowIndexResponse> UnfollowIndexAsync(IndexName index, Func<UnfollowIndexDescriptor, IUnfollowIndexRequest> selector = null,
			CancellationToken cancellationToken = default
		) =>
			UnfollowIndexAsync(selector.InvokeOrDefault(new UnfollowIndexDescriptor(index)), cancellationToken);

		/// <inheritdoc cref="UnfollowIndex(IndexName, System.Func{Nest6.UnfollowIndexDescriptor,Nest6.IUnfollowIndexRequest})" />
		public Task<IUnfollowIndexResponse> UnfollowIndexAsync(IUnfollowIndexRequest request, CancellationToken cancellationToken = default) =>
			Dispatcher.DispatchAsync<IUnfollowIndexRequest, UnfollowIndexRequestParameters, UnfollowIndexResponse, IUnfollowIndexResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.CcrUnfollowDispatchAsync<UnfollowIndexResponse>(p, c)
			);
	}
}
