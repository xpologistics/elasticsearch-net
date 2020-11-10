using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Gets follower stats. Returns shard-level stats about the following tasks associated with each shard for the specified indices.
		/// </summary>
		IFollowIndexStatsResponse FollowIndexStats(Indices indices, Func<FollowIndexStatsDescriptor, IFollowIndexStatsRequest> selector = null);

		/// <inheritdoc cref="FollowIndexStats(Indices, System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})" />
		IFollowIndexStatsResponse FollowIndexStats(IFollowIndexStatsRequest request);

		/// <inheritdoc cref="FollowIndexStats(Indices, System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})" />
		Task<IFollowIndexStatsResponse> FollowIndexStatsAsync(Indices indices, Func<FollowIndexStatsDescriptor, IFollowIndexStatsRequest> selector = null,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc cref="FollowIndexStats(Indices, System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})" />
		Task<IFollowIndexStatsResponse> FollowIndexStatsAsync(IFollowIndexStatsRequest request, CancellationToken cancellationToken = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="FollowIndexStats(Indices, System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})" />
		public IFollowIndexStatsResponse FollowIndexStats(Indices indices, Func<FollowIndexStatsDescriptor, IFollowIndexStatsRequest> selector = null) =>
			FollowIndexStats(selector.InvokeOrDefault(new FollowIndexStatsDescriptor().Index(indices)));

		/// <inheritdoc cref="FollowIndexStats(Indices, System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})" />
		public IFollowIndexStatsResponse FollowIndexStats(IFollowIndexStatsRequest request) =>
			Dispatcher.Dispatch<IFollowIndexStatsRequest, FollowIndexStatsRequestParameters, FollowIndexStatsResponse>(
				request,
				(p, d) => LowLevelDispatch.CcrFollowStatsDispatch<FollowIndexStatsResponse>(p)
			);

		/// <inheritdoc cref="FollowIndexStats(Indices, System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})" />
		public Task<IFollowIndexStatsResponse> FollowIndexStatsAsync(Indices indices, Func<FollowIndexStatsDescriptor, IFollowIndexStatsRequest> selector = null,
			CancellationToken cancellationToken = default
		) =>
			FollowIndexStatsAsync(selector.InvokeOrDefault(new FollowIndexStatsDescriptor().Index(indices)), cancellationToken);

		/// <inheritdoc cref="FollowIndexStats(Indices, System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})" />
		public Task<IFollowIndexStatsResponse> FollowIndexStatsAsync(IFollowIndexStatsRequest request, CancellationToken cancellationToken = default) =>
			Dispatcher.DispatchAsync<IFollowIndexStatsRequest, FollowIndexStatsRequestParameters, FollowIndexStatsResponse, IFollowIndexStatsResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.CcrFollowStatsDispatchAsync<FollowIndexStatsResponse>(p, c)
			);
	}
}
