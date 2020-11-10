﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Gets the current Watcher metrics
		/// </summary>
		IWatcherStatsResponse WatcherStats(Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null);

		/// <inheritdoc />
		IWatcherStatsResponse WatcherStats(IWatcherStatsRequest request);

		/// <inheritdoc />
		Task<IWatcherStatsResponse> WatcherStatsAsync(Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		Task<IWatcherStatsResponse> WatcherStatsAsync(IWatcherStatsRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IWatcherStatsResponse WatcherStats(Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null) =>
			WatcherStats(selector.InvokeOrDefault(new WatcherStatsDescriptor()));

		/// <inheritdoc />
		public IWatcherStatsResponse WatcherStats(IWatcherStatsRequest request) =>
			Dispatcher.Dispatch<IWatcherStatsRequest, WatcherStatsRequestParameters, WatcherStatsResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackWatcherStatsDispatch<WatcherStatsResponse>(p)
			);

		/// <inheritdoc />
		public Task<IWatcherStatsResponse> WatcherStatsAsync(Func<WatcherStatsDescriptor, IWatcherStatsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			WatcherStatsAsync(selector.InvokeOrDefault(new WatcherStatsDescriptor()), cancellationToken);

		/// <inheritdoc />
		public Task<IWatcherStatsResponse> WatcherStatsAsync(IWatcherStatsRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher.DispatchAsync<IWatcherStatsRequest, WatcherStatsRequestParameters, WatcherStatsResponse, IWatcherStatsResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackWatcherStatsDispatchAsync<WatcherStatsResponse>(p, c)
			);
	}
}
