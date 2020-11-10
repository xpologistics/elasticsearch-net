﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Stop a machine learning data feed.
		/// A datafeed that is stopped ceases to retrieve data from Elasticsearch. A datafeed can be started and stopped multiple times throughout its
		/// lifecycle.
		/// </summary>
		IStopDatafeedResponse StopDatafeed(Id datafeedId, Func<StopDatafeedDescriptor, IStopDatafeedRequest> selector = null);

		/// <inheritdoc />
		IStopDatafeedResponse StopDatafeed(IStopDatafeedRequest request);

		/// <inheritdoc />
		Task<IStopDatafeedResponse> StopDatafeedAsync(Id datafeedId, Func<StopDatafeedDescriptor, IStopDatafeedRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		Task<IStopDatafeedResponse> StopDatafeedAsync(IStopDatafeedRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IStopDatafeedResponse StopDatafeed(Id datafeedId, Func<StopDatafeedDescriptor, IStopDatafeedRequest> selector = null) =>
			StopDatafeed(selector.InvokeOrDefault(new StopDatafeedDescriptor(datafeedId)));

		/// <inheritdoc />
		public IStopDatafeedResponse StopDatafeed(IStopDatafeedRequest request) =>
			Dispatcher.Dispatch<IStopDatafeedRequest, StopDatafeedRequestParameters, StopDatafeedResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackMlStopDatafeedDispatch<StopDatafeedResponse>(p)
			);

		/// <inheritdoc />
		public Task<IStopDatafeedResponse> StopDatafeedAsync(Id datafeedId, Func<StopDatafeedDescriptor, IStopDatafeedRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			StopDatafeedAsync(selector.InvokeOrDefault(new StopDatafeedDescriptor(datafeedId)), cancellationToken);

		/// <inheritdoc />
		public Task<IStopDatafeedResponse> StopDatafeedAsync(IStopDatafeedRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher.DispatchAsync<IStopDatafeedRequest, StopDatafeedRequestParameters, StopDatafeedResponse, IStopDatafeedResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackMlStopDatafeedDispatchAsync<StopDatafeedResponse>(p, c)
			);
	}
}
