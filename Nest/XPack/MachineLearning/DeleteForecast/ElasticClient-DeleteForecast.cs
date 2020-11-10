﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deletes forecasts from a machine learning job.
		/// </summary>
		IDeleteForecastResponse DeleteForecast(Id jobId, ForecastIds forecastId, Func<DeleteForecastDescriptor, IDeleteForecastRequest> selector = null);

		/// <inheritdoc cref="DeleteForecast(Nest6.Id,Nest6.ForecastIds,System.Func{Nest6.DeleteForecastDescriptor,Nest6.IDeleteForecastRequest})" />
		IDeleteForecastResponse DeleteForecast(IDeleteForecastRequest request);

		/// <inheritdoc cref="DeleteForecast(Nest6.Id,Nest6.ForecastIds,System.Func{Nest6.DeleteForecastDescriptor,Nest6.IDeleteForecastRequest})" />
		Task<IDeleteForecastResponse> DeleteForecastAsync(Id jobId, ForecastIds forecastId, Func<DeleteForecastDescriptor, IDeleteForecastRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="DeleteForecast(Nest6.Id,Nest6.ForecastIds,System.Func{Nest6.DeleteForecastDescriptor,Nest6.IDeleteForecastRequest})" />
		Task<IDeleteForecastResponse> DeleteForecastAsync(IDeleteForecastRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="DeleteForecast(Nest6.Id,Nest6.ForecastIds,System.Func{Nest6.DeleteForecastDescriptor,Nest6.IDeleteForecastRequest})" />
		public IDeleteForecastResponse DeleteForecast(Id jobId, ForecastIds forecastId, Func<DeleteForecastDescriptor, IDeleteForecastRequest> selector = null) =>
			DeleteForecast(selector.InvokeOrDefault(new DeleteForecastDescriptor(jobId, forecastId)));

		/// <inheritdoc cref="DeleteForecast(Nest6.Id,Nest6.ForecastIds,System.Func{Nest6.DeleteForecastDescriptor,Nest6.IDeleteForecastRequest})" />
		public IDeleteForecastResponse DeleteForecast(IDeleteForecastRequest request) =>
			Dispatcher.Dispatch<IDeleteForecastRequest, DeleteForecastRequestParameters, DeleteForecastResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackMlDeleteForecastDispatch<DeleteForecastResponse>(p)
			);

		/// <inheritdoc cref="DeleteForecast(Nest6.Id,Nest6.ForecastIds,System.Func{Nest6.DeleteForecastDescriptor,Nest6.IDeleteForecastRequest})" />
		public Task<IDeleteForecastResponse> DeleteForecastAsync(Id jobId, ForecastIds forecastId,
			Func<DeleteForecastDescriptor, IDeleteForecastRequest> selector = null, CancellationToken cancellationToken = default(CancellationToken)) =>
			DeleteForecastAsync(selector.InvokeOrDefault(new DeleteForecastDescriptor(jobId, forecastId)), cancellationToken);

		/// <inheritdoc cref="DeleteForecast(Nest6.Id,Nest6.ForecastIds,System.Func{Nest6.DeleteForecastDescriptor,Nest6.IDeleteForecastRequest})" />
		public Task<IDeleteForecastResponse> DeleteForecastAsync(IDeleteForecastRequest request,
			CancellationToken cancellationToken = default(CancellationToken)) =>
			Dispatcher.DispatchAsync<IDeleteForecastRequest, DeleteForecastRequestParameters, DeleteForecastResponse, IDeleteForecastResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackMlDeleteForecastDispatchAsync<DeleteForecastResponse>(p, c)
			);
	}
}
