﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deletes an existing rollup job. The job can be started or stopped, in both cases it will be deleted.
		/// Attempting to delete a non-existing job will throw an exception
		/// </summary>
		IDeleteRollupJobResponse DeleteRollupJob(Id id, Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null);

		/// <inheritdoc cref="DeleteRollupJob(Nest6.Id,System.Func{Nest6.DeleteRollupJobDescriptor,Nest6.IDeleteRollupJobRequest})" />
		IDeleteRollupJobResponse DeleteRollupJob(IDeleteRollupJobRequest request);

		/// <inheritdoc cref="DeleteRollupJob(Nest6.Id,System.Func{Nest6.DeleteRollupJobDescriptor,Nest6.IDeleteRollupJobRequest})" />
		Task<IDeleteRollupJobResponse> DeleteRollupJobAsync(Id id,
			Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null, CancellationToken cancellationToken = default
		);

		/// <inheritdoc cref="DeleteRollupJob(Nest6.Id,System.Func{Nest6.DeleteRollupJobDescriptor,Nest6.IDeleteRollupJobRequest})" />
		Task<IDeleteRollupJobResponse> DeleteRollupJobAsync(IDeleteRollupJobRequest request, CancellationToken cancellationToken = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IDeleteRollupJobResponse DeleteRollupJob(Id id, Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null) =>
			DeleteRollupJob(selector.InvokeOrDefault(new DeleteRollupJobDescriptor(id)));

		/// <inheritdoc />
		public IDeleteRollupJobResponse DeleteRollupJob(IDeleteRollupJobRequest request) =>
			Dispatcher.Dispatch<IDeleteRollupJobRequest, DeleteRollupJobRequestParameters, DeleteRollupJobResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackRollupDeleteJobDispatch<DeleteRollupJobResponse>(p)
			);

		/// <inheritdoc />
		public Task<IDeleteRollupJobResponse> DeleteRollupJobAsync(
			Id id, Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null, CancellationToken cancellationToken = default
		) =>
			DeleteRollupJobAsync(selector.InvokeOrDefault(new DeleteRollupJobDescriptor(id)), cancellationToken);

		/// <inheritdoc />
		public Task<IDeleteRollupJobResponse> DeleteRollupJobAsync(IDeleteRollupJobRequest request, CancellationToken cancellationToken = default) =>
			Dispatcher.DispatchAsync<IDeleteRollupJobRequest, DeleteRollupJobRequestParameters, DeleteRollupJobResponse, IDeleteRollupJobResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackRollupDeleteJobDispatchAsync<DeleteRollupJobResponse>(p, c)
			);
	}
}
