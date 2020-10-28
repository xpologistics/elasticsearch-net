using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Retrieve information about the scheduled events in calendars.
		/// </summary>
		IGetCalendarEventsResponse GetCalendarEvents(Id calendarId, Func<GetCalendarEventsDescriptor, IGetCalendarEventsRequest> selector = null);

		/// <inheritdoc cref="GetCalendarEvents(Nest6.Id,System.Func{Nest6.GetCalendarEventsDescriptor,Nest6.IGetCalendarEventsRequest})" />
		IGetCalendarEventsResponse GetCalendarEvents(IGetCalendarEventsRequest request);

		/// <inheritdoc cref="GetCalendarEvents(Nest6.Id,System.Func{Nest6.GetCalendarEventsDescriptor,Nest6.IGetCalendarEventsRequest})" />
		Task<IGetCalendarEventsResponse> GetCalendarEventsAsync(Id calendarId, Func<GetCalendarEventsDescriptor, IGetCalendarEventsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="GetCalendarEvents(Nest6.Id,System.Func{Nest6.GetCalendarEventsDescriptor,Nest6.IGetCalendarEventsRequest})" />
		Task<IGetCalendarEventsResponse> GetCalendarEventsAsync(IGetCalendarEventsRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="IElasticClient.GetCalendarEvents(Nest6.Id,System.Func{Nest6.GetCalendarEventsDescriptor,Nest6.IGetCalendarEventsRequest})" />
		public IGetCalendarEventsResponse GetCalendarEvents(Id calendarId, Func<GetCalendarEventsDescriptor, IGetCalendarEventsRequest> selector = null) =>
			GetCalendarEvents(selector.InvokeOrDefault(new GetCalendarEventsDescriptor(calendarId)));

		/// <inheritdoc cref="IElasticClient.GetCalendarEvents(Nest6.Id,System.Func{Nest6.GetCalendarEventsDescriptor,Nest6.IGetCalendarEventsRequest})" />
		public IGetCalendarEventsResponse GetCalendarEvents(IGetCalendarEventsRequest request) =>
			Dispatcher.Dispatch<IGetCalendarEventsRequest, GetCalendarEventsRequestParameters, GetCalendarEventsResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackMlGetCalendarEventsDispatch<GetCalendarEventsResponse>(p)
			);

		/// <inheritdoc cref="IElasticClient.GetCalendarEvents(Nest6.Id,System.Func{Nest6.GetCalendarEventsDescriptor,Nest6.IGetCalendarEventsRequest})" />
		public Task<IGetCalendarEventsResponse> GetCalendarEventsAsync(Id calendarId, Func<GetCalendarEventsDescriptor, IGetCalendarEventsRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) => GetCalendarEventsAsync(selector.InvokeOrDefault(new GetCalendarEventsDescriptor(calendarId)), cancellationToken);

		/// <inheritdoc cref="IElasticClient.GetCalendarEvents(Nest6.Id,System.Func{Nest6.GetCalendarEventsDescriptor,Nest6.IGetCalendarEventsRequest})" />
		public Task<IGetCalendarEventsResponse> GetCalendarEventsAsync(IGetCalendarEventsRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			Dispatcher.DispatchAsync<IGetCalendarEventsRequest, GetCalendarEventsRequestParameters, GetCalendarEventsResponse, IGetCalendarEventsResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackMlGetCalendarEventsDispatchAsync<GetCalendarEventsResponse>(p, c)
			);
	}
}
