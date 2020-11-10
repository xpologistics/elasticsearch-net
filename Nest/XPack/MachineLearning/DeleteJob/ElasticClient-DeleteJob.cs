﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deletes a machine learning job.
		/// Before you can delete a job, you must delete the datafeeds that are associated with it, see DeleteDatafeed.
		/// Unless the force parameter is used, the job must be closed before it can be deleted.
		/// </summary>
		/// <remarks>
		/// It is not currently possible to delete multiple jobs, either using wildcards or a comma separated list.
		/// </remarks>
		IDeleteJobResponse DeleteJob(Id jobId, Func<DeleteJobDescriptor, IDeleteJobRequest> selector = null);

		/// <inheritdoc />
		IDeleteJobResponse DeleteJob(IDeleteJobRequest request);

		/// <inheritdoc />
		Task<IDeleteJobResponse> DeleteJobAsync(Id jobId, Func<DeleteJobDescriptor, IDeleteJobRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		Task<IDeleteJobResponse> DeleteJobAsync(IDeleteJobRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IDeleteJobResponse DeleteJob(Id jobId, Func<DeleteJobDescriptor, IDeleteJobRequest> selector = null) =>
			DeleteJob(selector.InvokeOrDefault(new DeleteJobDescriptor(jobId)));

		/// <inheritdoc />
		public IDeleteJobResponse DeleteJob(IDeleteJobRequest request) =>
			Dispatcher.Dispatch<IDeleteJobRequest, DeleteJobRequestParameters, DeleteJobResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackMlDeleteJobDispatch<DeleteJobResponse>(p)
			);

		/// <inheritdoc />
		public Task<IDeleteJobResponse> DeleteJobAsync(Id jobId, Func<DeleteJobDescriptor, IDeleteJobRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			DeleteJobAsync(selector.InvokeOrDefault(new DeleteJobDescriptor(jobId)), cancellationToken);

		/// <inheritdoc />
		public Task<IDeleteJobResponse> DeleteJobAsync(IDeleteJobRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			Dispatcher.DispatchAsync<IDeleteJobRequest, DeleteJobRequestParameters, DeleteJobResponse, IDeleteJobResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackMlDeleteJobDispatchAsync<DeleteJobResponse>(p, c)
			);
	}
}
