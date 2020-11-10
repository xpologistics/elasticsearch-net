﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Allows to update cluster wide specific settings. Settings updated can either be persistent
		/// (applied cross restarts) or transient (will not survive a full cluster restart).
		/// <para> </para>
		/// http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/cluster-update-settings.html
		/// </summary>
		IClusterPutSettingsResponse ClusterPutSettings(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector);

		/// <inheritdoc />
		Task<IClusterPutSettingsResponse> ClusterPutSettingsAsync(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		IClusterPutSettingsResponse ClusterPutSettings(IClusterPutSettingsRequest request);

		/// <inheritdoc />
		Task<IClusterPutSettingsResponse> ClusterPutSettingsAsync(IClusterPutSettingsRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IClusterPutSettingsResponse ClusterPutSettings(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector) =>
			ClusterPutSettings(selector.InvokeOrDefault(new ClusterPutSettingsDescriptor()));

		/// <inheritdoc />
		public IClusterPutSettingsResponse ClusterPutSettings(IClusterPutSettingsRequest request) =>
			Dispatcher.Dispatch<IClusterPutSettingsRequest, ClusterPutSettingsRequestParameters, ClusterPutSettingsResponse>(
				request,
				LowLevelDispatch.ClusterPutSettingsDispatch<ClusterPutSettingsResponse>
			);

		/// <inheritdoc />
		public Task<IClusterPutSettingsResponse> ClusterPutSettingsAsync(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			ClusterPutSettingsAsync(selector.InvokeOrDefault(new ClusterPutSettingsDescriptor()), cancellationToken);

		/// <inheritdoc />
		public Task<IClusterPutSettingsResponse> ClusterPutSettingsAsync(IClusterPutSettingsRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher
				.DispatchAsync<IClusterPutSettingsRequest, ClusterPutSettingsRequestParameters, ClusterPutSettingsResponse,
					IClusterPutSettingsResponse>(
					request,
					cancellationToken,
					LowLevelDispatch.ClusterPutSettingsDispatchAsync<ClusterPutSettingsResponse>
				);
	}
}
