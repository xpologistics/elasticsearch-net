using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Gets cross-cluster replication stats. This API will return all stats related to cross-cluster replication.
		/// In particular, this API returns stats about auto-following, and returns the same shard-level stats as in the get
		/// follower stats API. <see cref="IElasticClient.FollowIndexStats(Nest6.Indices,System.Func{Nest6.FollowIndexStatsDescriptor,Nest6.IFollowIndexStatsRequest})"/>
		/// </summary>
		ICcrStatsResponse CcrStats(Func<CcrStatsDescriptor, ICcrStatsRequest> selector = null);

		/// <inheritdoc cref="CcrStats(System.Func{Nest6.CcrStatsDescriptor,Nest6.ICcrStatsRequest})" />
		ICcrStatsResponse CcrStats(ICcrStatsRequest request);

		/// <inheritdoc cref="CcrStats(System.Func{Nest6.CcrStatsDescriptor,Nest6.ICcrStatsRequest})" />
		Task<ICcrStatsResponse> CcrStatsAsync(Func<CcrStatsDescriptor, ICcrStatsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="CcrStats(System.Func{Nest6.CcrStatsDescriptor,Nest6.ICcrStatsRequest})" />
		Task<ICcrStatsResponse> CcrStatsAsync(ICcrStatsRequest request, CancellationToken cancellationToken = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="CcrStats(System.Func{Nest6.CcrStatsDescriptor,Nest6.ICcrStatsRequest})" />
		public ICcrStatsResponse CcrStats(Func<CcrStatsDescriptor, ICcrStatsRequest> selector = null) =>
			CcrStats(selector.InvokeOrDefault(new CcrStatsDescriptor()));

		/// <inheritdoc cref="CcrStats(System.Func{Nest6.CcrStatsDescriptor,Nest6.ICcrStatsRequest})" />
		public ICcrStatsResponse CcrStats(ICcrStatsRequest request) =>
			Dispatcher.Dispatch<ICcrStatsRequest, CcrStatsRequestParameters, CcrStatsResponse>(
				request,
				(p, d) => LowLevelDispatch.CcrStatsDispatch<CcrStatsResponse>(p)
			);

		/// <inheritdoc cref="CcrStats(System.Func{Nest6.CcrStatsDescriptor,Nest6.ICcrStatsRequest})" />
		public Task<ICcrStatsResponse> CcrStatsAsync(Func<CcrStatsDescriptor, ICcrStatsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			CcrStatsAsync(selector.InvokeOrDefault(new CcrStatsDescriptor()), cancellationToken);

		/// <inheritdoc cref="CcrStats(System.Func{Nest6.CcrStatsDescriptor,Nest6.ICcrStatsRequest})" />
		public Task<ICcrStatsResponse> CcrStatsAsync(ICcrStatsRequest request, CancellationToken cancellationToken = default) =>
			Dispatcher.DispatchAsync<ICcrStatsRequest, CcrStatsRequestParameters, CcrStatsResponse, ICcrStatsResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.CcrStatsDispatchAsync<CcrStatsResponse>(p, c)
			);
	}
}
