using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deletes a machine learning calendar.
		/// Removes all scheduled events from the calendar then deletes the calendar.
		/// </summary>
		IDeleteCalendarJobResponse DeleteCalendarJob(Id calendarId, Id jobId, Func<DeleteCalendarJobDescriptor, IDeleteCalendarJobRequest> selector = null);

		/// <inheritdoc cref="DeleteCalendarJob(Nest6.Id,Nest6.Id,System.Func{Nest6.DeleteCalendarJobDescriptor,Nest6.IDeleteCalendarJobRequest})" />
		IDeleteCalendarJobResponse DeleteCalendarJob(IDeleteCalendarJobRequest request);

		/// <inheritdoc cref="DeleteCalendarJob(Nest6.Id,Nest6.Id,System.Func{Nest6.DeleteCalendarJobDescriptor,Nest6.IDeleteCalendarJobRequest})" />
		Task<IDeleteCalendarJobResponse> DeleteCalendarJobAsync(Id calendarId, Id jobId, Func<DeleteCalendarJobDescriptor, IDeleteCalendarJobRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="DeleteCalendarJob(Nest6.Id,Nest6.Id,System.Func{Nest6.DeleteCalendarJobDescriptor,Nest6.IDeleteCalendarJobRequest})" />
		Task<IDeleteCalendarJobResponse> DeleteCalendarJobAsync(IDeleteCalendarJobRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IDeleteCalendarJobResponse DeleteCalendarJob(Id calendarId, Id jobId, Func<DeleteCalendarJobDescriptor, IDeleteCalendarJobRequest> selector = null) =>
			DeleteCalendarJob(selector.InvokeOrDefault(new DeleteCalendarJobDescriptor(calendarId, jobId)));

		/// <inheritdoc />
		public IDeleteCalendarJobResponse DeleteCalendarJob(IDeleteCalendarJobRequest request) =>
			Dispatcher.Dispatch<IDeleteCalendarJobRequest, DeleteCalendarJobRequestParameters, DeleteCalendarJobResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackMlDeleteCalendarJobDispatch<DeleteCalendarJobResponse>(p)
			);

		/// <inheritdoc />
		public Task<IDeleteCalendarJobResponse> DeleteCalendarJobAsync(Id calendarId, Id jobId, Func<DeleteCalendarJobDescriptor, IDeleteCalendarJobRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			DeleteCalendarJobAsync(selector.InvokeOrDefault(new DeleteCalendarJobDescriptor(calendarId, jobId)), cancellationToken);

		/// <inheritdoc />
		public Task<IDeleteCalendarJobResponse> DeleteCalendarJobAsync(IDeleteCalendarJobRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			Dispatcher.DispatchAsync<IDeleteCalendarJobRequest, DeleteCalendarJobRequestParameters, DeleteCalendarJobResponse, IDeleteCalendarJobResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackMlDeleteCalendarJobDispatchAsync<DeleteCalendarJobResponse>(p, c)
			);
	}
}
