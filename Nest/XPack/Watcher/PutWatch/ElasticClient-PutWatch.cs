using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch6.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Registers a new watch in Watcher or updates an existing one.
		/// Once registered, a new document will be added to the .watches index, representing the watch,
		/// and its trigger will immediately be registered with the relevant trigger engine.
		/// </summary>
		IPutWatchResponse PutWatch(Id watchId, Func<PutWatchDescriptor, IPutWatchRequest> selector = null);

		/// <inheritdoc cref="PutWatch(Nest6.Id,System.Func{Nest6.PutWatchDescriptor,Nest6.IPutWatchRequest})" />
		IPutWatchResponse PutWatch(IPutWatchRequest request);

		/// <inheritdoc cref="PutWatch(Nest6.Id,System.Func{Nest6.PutWatchDescriptor,Nest6.IPutWatchRequest})" />
		Task<IPutWatchResponse> PutWatchAsync(Id watchId, Func<PutWatchDescriptor, IPutWatchRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="PutWatch(Nest6.Id,System.Func{Nest6.PutWatchDescriptor,Nest6.IPutWatchRequest})" />
		Task<IPutWatchResponse> PutWatchAsync(IPutWatchRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IPutWatchResponse PutWatch(Id watchId, Func<PutWatchDescriptor, IPutWatchRequest> selector = null) =>
			PutWatch(selector.InvokeOrDefault(new PutWatchDescriptor(watchId)));

		/// <inheritdoc />
		public IPutWatchResponse PutWatch(IPutWatchRequest request) =>
			Dispatcher.Dispatch<IPutWatchRequest, PutWatchRequestParameters, PutWatchResponse>(
				request,
				LowLevelDispatch.XpackWatcherPutWatchDispatch<PutWatchResponse>
			);

		/// <inheritdoc />
		public Task<IPutWatchResponse> PutWatchAsync(Id watchId, Func<PutWatchDescriptor, IPutWatchRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			PutWatchAsync(selector.InvokeOrDefault(new PutWatchDescriptor(watchId)), cancellationToken);

		/// <inheritdoc />
		public Task<IPutWatchResponse> PutWatchAsync(IPutWatchRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			Dispatcher.DispatchAsync<IPutWatchRequest, PutWatchRequestParameters, PutWatchResponse, IPutWatchResponse>(
				request,
				cancellationToken,
				LowLevelDispatch.XpackWatcherPutWatchDispatchAsync<PutWatchResponse>
			);
	}
}
