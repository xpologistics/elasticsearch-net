using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch6.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Shows an index’s current lifecycle status.
		/// Retrieves information about the index’s current lifecycle state, such as the currently executing phase, action, and step.
		/// Shows when the index entered each one, the definition of the running phase, and information about any failures.
		/// </summary>
		IExplainLifecycleResponse ExplainLifecycle(IndexName index, Func<ExplainLifecycleDescriptor, IExplainLifecycleRequest> selector = null);

		/// <inheritdoc cref="ExplainLifecycle(Nest6.IndexName,System.Func{Nest6.ExplainLifecycleDescriptor,Nest6.IExplainLifecycleRequest})" />
		IExplainLifecycleResponse ExplainLifecycle(IExplainLifecycleRequest request);

		/// <inheritdoc cref="ExplainLifecycle(Nest6.IndexName,System.Func{Nest6.ExplainLifecycleDescriptor,Nest6.IExplainLifecycleRequest})" />
		Task<IExplainLifecycleResponse> ExplainLifecycleAsync(IndexName index, Func<ExplainLifecycleDescriptor, IExplainLifecycleRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="ExplainLifecycle(Nest6.IndexName,System.Func{Nest6.ExplainLifecycleDescriptor,Nest6.IExplainLifecycleRequest})" />
		Task<IExplainLifecycleResponse> ExplainLifecycleAsync(IExplainLifecycleRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="ExplainLifecycle(Nest6.IndexName,System.Func{Nest6.ExplainLifecycleDescriptor,Nest6.IExplainLifecycleRequest})" />
		public IExplainLifecycleResponse ExplainLifecycle(IndexName index, Func<ExplainLifecycleDescriptor, IExplainLifecycleRequest> selector = null) =>
			ExplainLifecycle(selector.InvokeOrDefault(new ExplainLifecycleDescriptor(index)));

		/// <inheritdoc cref="ExplainLifecycle(Nest6.IndexName,System.Func{Nest6.ExplainLifecycleDescriptor,Nest6.IExplainLifecycleRequest})" />
		public IExplainLifecycleResponse ExplainLifecycle(IExplainLifecycleRequest request) =>
			Dispatcher.Dispatch<IExplainLifecycleRequest, ExplainLifecycleRequestParameters, ExplainLifecycleResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackIlmExplainLifecycleDispatch<ExplainLifecycleResponse>(p)
			);

		/// <inheritdoc cref="ExplainLifecycle(Nest6.IndexName,System.Func{Nest6.ExplainLifecycleDescriptor,Nest6.IExplainLifecycleRequest})" />
		public Task<IExplainLifecycleResponse> ExplainLifecycleAsync(IndexName index, Func<ExplainLifecycleDescriptor, IExplainLifecycleRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			ExplainLifecycleAsync(selector.InvokeOrDefault(new ExplainLifecycleDescriptor(index)), cancellationToken);

		/// <inheritdoc cref="ExplainLifecycle(Nest6.IndexName,System.Func{Nest6.ExplainLifecycleDescriptor,Nest6.IExplainLifecycleRequest})" />
		public Task<IExplainLifecycleResponse> ExplainLifecycleAsync(IExplainLifecycleRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher.DispatchAsync<IExplainLifecycleRequest, ExplainLifecycleRequestParameters, ExplainLifecycleResponse, IExplainLifecycleResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackIlmExplainLifecycleDispatchAsync<ExplainLifecycleResponse>(p, c)
			);
	}
}
