﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Retrieves machine learning job configuration information
		/// </summary>
		IGetJobsResponse GetJobs(Func<GetJobsDescriptor, IGetJobsRequest> selector = null);

		/// <inheritdoc />
		IGetJobsResponse GetJobs(IGetJobsRequest request);

		/// <inheritdoc />
		Task<IGetJobsResponse> GetJobsAsync(Func<GetJobsDescriptor, IGetJobsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		Task<IGetJobsResponse> GetJobsAsync(IGetJobsRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IGetJobsResponse GetJobs(Func<GetJobsDescriptor, IGetJobsRequest> selector = null) =>
			GetJobs(selector.InvokeOrDefault(new GetJobsDescriptor()));

		/// <inheritdoc />
		public IGetJobsResponse GetJobs(IGetJobsRequest request) =>
			Dispatcher.Dispatch<IGetJobsRequest, GetJobsRequestParameters, GetJobsResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackMlGetJobsDispatch<GetJobsResponse>(p)
			);

		/// <inheritdoc />
		public Task<IGetJobsResponse> GetJobsAsync(Func<GetJobsDescriptor, IGetJobsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			GetJobsAsync(selector.InvokeOrDefault(new GetJobsDescriptor()), cancellationToken);

		/// <inheritdoc />
		public Task<IGetJobsResponse> GetJobsAsync(IGetJobsRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			Dispatcher.DispatchAsync<IGetJobsRequest, GetJobsRequestParameters, GetJobsResponse, IGetJobsResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackMlGetJobsDispatchAsync<GetJobsResponse>(p, c)
			);
	}
}
