using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch6.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Updates the description of a machine learning filter, adds items, or removes items.
		/// </summary>
		IUpdateFilterResponse UpdateFilter(Id filterId, Func<UpdateFilterDescriptor, IUpdateFilterRequest> selector = null);

		/// <inheritdoc cref="UpdateFilter(Nest6.Id,System.Func{Nest6.UpdateFilterDescriptor,Nest6.IUpdateFilterRequest})" />
		IUpdateFilterResponse UpdateFilter(IUpdateFilterRequest request);

		/// <inheritdoc cref="UpdateFilter(Nest6.Id,System.Func{Nest6.UpdateFilterDescriptor,Nest6.IUpdateFilterRequest})" />
		Task<IUpdateFilterResponse> UpdateFilterAsync(Id filterId, Func<UpdateFilterDescriptor, IUpdateFilterRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc cref="UpdateFilter(Nest6.Id,System.Func{Nest6.UpdateFilterDescriptor,Nest6.IUpdateFilterRequest})" />
		Task<IUpdateFilterResponse> UpdateFilterAsync(IUpdateFilterRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IUpdateFilterResponse UpdateFilter(Id filterId, Func<UpdateFilterDescriptor, IUpdateFilterRequest> selector = null) =>
			UpdateFilter(selector.InvokeOrDefault(new UpdateFilterDescriptor(filterId)));

		/// <inheritdoc />
		public IUpdateFilterResponse UpdateFilter(IUpdateFilterRequest request) =>
			Dispatcher.Dispatch<IUpdateFilterRequest, UpdateFilterRequestParameters, UpdateFilterResponse>(
				request,
				LowLevelDispatch.XpackMlUpdateFilterDispatch<UpdateFilterResponse>
			);

		/// <inheritdoc />
		public Task<IUpdateFilterResponse> UpdateFilterAsync(Id filterId, Func<UpdateFilterDescriptor, IUpdateFilterRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			UpdateFilterAsync(selector.InvokeOrDefault(new UpdateFilterDescriptor(filterId)), cancellationToken);

		/// <inheritdoc />
		public Task<IUpdateFilterResponse> UpdateFilterAsync(IUpdateFilterRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			Dispatcher.DispatchAsync<IUpdateFilterRequest, UpdateFilterRequestParameters, UpdateFilterResponse, IUpdateFilterResponse>(
				request,
				cancellationToken,
				LowLevelDispatch.XpackMlUpdateFilterDispatchAsync<UpdateFilterResponse>
			);
	}
}
