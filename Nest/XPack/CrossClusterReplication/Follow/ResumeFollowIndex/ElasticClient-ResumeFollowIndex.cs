﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Resumes a follower index that has been paused either explicitly with the pause follower API or
		/// implicitly due to execution that can not be retried due to failure during following. When this API returns,
		/// the follower index will resume fetching operations from the leader index.
		/// </summary>
		IResumeFollowIndexResponse ResumeFollowIndex(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest6.ResumeFollowIndexDescriptor,Nest6.IResumeFollowIndexRequest})" />
		IResumeFollowIndexResponse ResumeFollowIndex(IResumeFollowIndexRequest request);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest6.ResumeFollowIndexDescriptor,Nest6.IResumeFollowIndexRequest})" />
		Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest6.ResumeFollowIndexDescriptor,Nest6.IResumeFollowIndexRequest})" />
		Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(IResumeFollowIndexRequest request, CancellationToken cancellationToken = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest6.ResumeFollowIndexDescriptor,Nest6.IResumeFollowIndexRequest})" />
		public IResumeFollowIndexResponse ResumeFollowIndex(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null) =>
			ResumeFollowIndex(selector.InvokeOrDefault(new ResumeFollowIndexDescriptor(index)));

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest6.ResumeFollowIndexDescriptor,Nest6.IResumeFollowIndexRequest})" />
		public IResumeFollowIndexResponse ResumeFollowIndex(IResumeFollowIndexRequest request) =>
			Dispatcher.Dispatch<IResumeFollowIndexRequest, ResumeFollowIndexRequestParameters, ResumeFollowIndexResponse>(
				request,
				(p, d) => LowLevelDispatch.CcrResumeFollowDispatch<ResumeFollowIndexResponse>(p, d)
			);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest6.ResumeFollowIndexDescriptor,Nest6.IResumeFollowIndexRequest})" />
		public Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null,
			CancellationToken cancellationToken = default
		) =>
			ResumeFollowIndexAsync(selector.InvokeOrDefault(new ResumeFollowIndexDescriptor(index)), cancellationToken);

		/// <inheritdoc cref="ResumeFollowIndex(IndexName, System.Func{Nest6.ResumeFollowIndexDescriptor,Nest6.IResumeFollowIndexRequest})" />
		public Task<IResumeFollowIndexResponse> ResumeFollowIndexAsync(IResumeFollowIndexRequest request, CancellationToken cancellationToken = default) =>
			Dispatcher.DispatchAsync<IResumeFollowIndexRequest, ResumeFollowIndexRequestParameters, ResumeFollowIndexResponse, IResumeFollowIndexResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.CcrResumeFollowDispatchAsync<ResumeFollowIndexResponse>(p, d, c)
			);
	}
}
