using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch6.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary> Gets configured auto-follow patterns. Returns the specified auto-follow pattern collection. </summary>
		IGetAutoFollowPatternResponse GetAutoFollowPattern(Func<GetAutoFollowPatternDescriptor, IGetAutoFollowPatternRequest> selector = null);

		/// <inheritdoc cref="GetAutoFollowPattern(System.Func{Nest6.GetAutoFollowPatternDescriptor,Nest6.IGetAutoFollowPatternRequest})" />
		IGetAutoFollowPatternResponse GetAutoFollowPattern(IGetAutoFollowPatternRequest request);

		/// <inheritdoc cref="GetAutoFollowPattern(System.Func{Nest6.GetAutoFollowPatternDescriptor,Nest6.IGetAutoFollowPatternRequest})" />
		Task<IGetAutoFollowPatternResponse> GetAutoFollowPatternAsync(Func<GetAutoFollowPatternDescriptor, IGetAutoFollowPatternRequest> selector = null,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc cref="GetAutoFollowPattern(System.Func{Nest6.GetAutoFollowPatternDescriptor,Nest6.IGetAutoFollowPatternRequest})" />
		Task<IGetAutoFollowPatternResponse> GetAutoFollowPatternAsync(IGetAutoFollowPatternRequest request, CancellationToken cancellationToken = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="GetAutoFollowPattern(System.Func{Nest6.GetAutoFollowPatternDescriptor,Nest6.IGetAutoFollowPatternRequest})" />
		public IGetAutoFollowPatternResponse GetAutoFollowPattern(Func<GetAutoFollowPatternDescriptor, IGetAutoFollowPatternRequest> selector = null) =>
			GetAutoFollowPattern(selector.InvokeOrDefault(new GetAutoFollowPatternDescriptor()));

		/// <inheritdoc cref="GetAutoFollowPattern(System.Func{Nest6.GetAutoFollowPatternDescriptor,Nest6.IGetAutoFollowPatternRequest})" />
		public IGetAutoFollowPatternResponse GetAutoFollowPattern(IGetAutoFollowPatternRequest request) =>
			Dispatcher.Dispatch<IGetAutoFollowPatternRequest, GetAutoFollowPatternRequestParameters, GetAutoFollowPatternResponse>(
				request,
				(p, d) => LowLevelDispatch.CcrGetAutoFollowPatternDispatch<GetAutoFollowPatternResponse>(p)
			);

		/// <inheritdoc cref="GetAutoFollowPattern(System.Func{Nest6.GetAutoFollowPatternDescriptor,Nest6.IGetAutoFollowPatternRequest})" />
		public Task<IGetAutoFollowPatternResponse> GetAutoFollowPatternAsync(Func<GetAutoFollowPatternDescriptor, IGetAutoFollowPatternRequest> selector = null,
			CancellationToken cancellationToken = default
		) =>
			GetAutoFollowPatternAsync(selector.InvokeOrDefault(new GetAutoFollowPatternDescriptor()), cancellationToken);

		/// <inheritdoc cref="GetAutoFollowPattern(System.Func{Nest6.GetAutoFollowPatternDescriptor,Nest6.IGetAutoFollowPatternRequest})" />
		public Task<IGetAutoFollowPatternResponse> GetAutoFollowPatternAsync(IGetAutoFollowPatternRequest request, CancellationToken cancellationToken = default) =>
			Dispatcher.DispatchAsync<IGetAutoFollowPatternRequest, GetAutoFollowPatternRequestParameters, GetAutoFollowPatternResponse, IGetAutoFollowPatternResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.CcrGetAutoFollowPatternDispatchAsync<GetAutoFollowPatternResponse>(p, c)
			);
	}
}
