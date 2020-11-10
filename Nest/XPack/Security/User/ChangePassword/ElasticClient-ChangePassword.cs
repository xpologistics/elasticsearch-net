﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <inheritdoc />
		IChangePasswordResponse ChangePassword(Func<ChangePasswordDescriptor, IChangePasswordRequest> selector);

		/// <inheritdoc />
		IChangePasswordResponse ChangePassword(IChangePasswordRequest request);

		/// <inheritdoc />
		Task<IChangePasswordResponse> ChangePasswordAsync(Func<ChangePasswordDescriptor, IChangePasswordRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		Task<IChangePasswordResponse> ChangePasswordAsync(IChangePasswordRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IChangePasswordResponse ChangePassword(Func<ChangePasswordDescriptor, IChangePasswordRequest> selector) =>
			ChangePassword(selector.InvokeOrDefault(new ChangePasswordDescriptor()));

		/// <inheritdoc />
		public IChangePasswordResponse ChangePassword(IChangePasswordRequest request) =>
			Dispatcher.Dispatch<IChangePasswordRequest, ChangePasswordRequestParameters, ChangePasswordResponse>(
				request,
				(p, d) => LowLevelDispatch.XpackSecurityChangePasswordDispatch<ChangePasswordResponse>(p, d)
			);

		/// <inheritdoc />
		public Task<IChangePasswordResponse> ChangePasswordAsync(Func<ChangePasswordDescriptor, IChangePasswordRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			ChangePasswordAsync(selector.InvokeOrDefault(new ChangePasswordDescriptor()), cancellationToken);

		/// <inheritdoc />
		public Task<IChangePasswordResponse> ChangePasswordAsync(IChangePasswordRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher.DispatchAsync<IChangePasswordRequest, ChangePasswordRequestParameters, ChangePasswordResponse, IChangePasswordResponse>(
				request,
				cancellationToken,
				(p, d, c) => LowLevelDispatch.XpackSecurityChangePasswordDispatchAsync<ChangePasswordResponse>(p, d, c)
			);
	}
}
