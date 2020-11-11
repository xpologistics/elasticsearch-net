using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch6.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Creates a new follower index that is configured to follow the referenced leader index.
		/// When this API returns, the follower index exists, and cross-cluster replication starts replicating
		/// operations from the leader index to the follower index.
		/// </summary>
		ICreateFollowIndexResponse CreateFollowIndex(IndexName index, Func<CreateFollowIndexDescriptor, ICreateFollowIndexRequest> selector);

		/// <inheritdoc cref="CreateFollowIndex(IndexName, System.Func{Nest6.CreateFollowIndexDescriptor,Nest6.ICreateFollowIndexRequest})" />
		ICreateFollowIndexResponse CreateFollowIndex(ICreateFollowIndexRequest request);

		/// <inheritdoc cref="CreateFollowIndex(IndexName, System.Func{Nest6.CreateFollowIndexDescriptor,Nest6.ICreateFollowIndexRequest})" />
		Task<ICreateFollowIndexResponse> CreateFollowIndexAsync(IndexName index, Func<CreateFollowIndexDescriptor, ICreateFollowIndexRequest> selector,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc cref="CreateFollowIndex(IndexName, System.Func{Nest6.CreateFollowIndexDescriptor,Nest6.ICreateFollowIndexRequest})" />
		Task<ICreateFollowIndexResponse> CreateFollowIndexAsync(ICreateFollowIndexRequest request, CancellationToken cancellationToken = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="CreateFollowIndex(IndexName, System.Func{Nest6.CreateFollowIndexDescriptor,Nest6.ICreateFollowIndexRequest})" />
		public ICreateFollowIndexResponse CreateFollowIndex(IndexName index, Func<CreateFollowIndexDescriptor, ICreateFollowIndexRequest> selector) =>
			CreateFollowIndex(selector.InvokeOrDefault(new CreateFollowIndexDescriptor(index)));

		/// <inheritdoc cref="CreateFollowIndex(IndexName, System.Func{Nest6.CreateFollowIndexDescriptor,Nest6.ICreateFollowIndexRequest})" />
		public ICreateFollowIndexResponse CreateFollowIndex(ICreateFollowIndexRequest request) =>
			Dispatcher.Dispatch<ICreateFollowIndexRequest, CreateFollowIndexRequestParameters, CreateFollowIndexResponse>(
				request,
				(p, d) => LowLevelDispatch.CcrFollowDispatch<CreateFollowIndexResponse>(p, d)
			);

		/// <inheritdoc cref="CreateFollowIndex(IndexName, System.Func{Nest6.CreateFollowIndexDescriptor,Nest6.ICreateFollowIndexRequest})" />
		public Task<ICreateFollowIndexResponse> CreateFollowIndexAsync(IndexName index, Func<CreateFollowIndexDescriptor, ICreateFollowIndexRequest> selector,
			CancellationToken cancellationToken = default
		) =>
			CreateFollowIndexAsync(selector.InvokeOrDefault(new CreateFollowIndexDescriptor(index)), cancellationToken);

		/// <inheritdoc cref="CreateFollowIndex(IndexName, System.Func{Nest6.CreateFollowIndexDescriptor,Nest6.ICreateFollowIndexRequest})" />
		public Task<ICreateFollowIndexResponse> CreateFollowIndexAsync(ICreateFollowIndexRequest request, CancellationToken cancellationToken = default) =>
			Dispatcher.DispatchAsync<ICreateFollowIndexRequest, CreateFollowIndexRequestParameters, CreateFollowIndexResponse, ICreateFollowIndexResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.CcrFollowDispatchAsync<CreateFollowIndexResponse>(p, d, c)
			);
	}
}
