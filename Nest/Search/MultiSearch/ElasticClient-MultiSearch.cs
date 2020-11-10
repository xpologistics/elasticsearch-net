﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	using MultiSearchCreator = Func<IApiCallDetails, Stream, MultiSearchResponse>;

	public partial interface IElasticClient
	{
		/// <summary>
		/// The multi search API allows to execute several search requests within the same API.
		/// <para> </para>
		/// <a href="http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-multi-search.html">http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-multi-search.html</a>
		/// </summary>
		/// <param name="selector">A descriptor that describes the search operations on the multi search api</param>
		IMultiSearchResponse MultiSearch(Func<MultiSearchDescriptor, IMultiSearchRequest> selector);

		/// <inheritdoc />
		IMultiSearchResponse MultiSearch(IMultiSearchRequest request);

		/// <inheritdoc />
		Task<IMultiSearchResponse> MultiSearchAsync(Func<MultiSearchDescriptor, IMultiSearchRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		Task<IMultiSearchResponse> MultiSearchAsync(IMultiSearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IMultiSearchResponse MultiSearch(Func<MultiSearchDescriptor, IMultiSearchRequest> selector) =>
			MultiSearch(selector?.Invoke(new MultiSearchDescriptor()));

		/// <inheritdoc />
		public IMultiSearchResponse MultiSearch(IMultiSearchRequest request) =>
			Dispatcher.Dispatch<IMultiSearchRequest, MultiSearchRequestParameters, MultiSearchResponse>(
				request,
				(p, d) =>
				{
					var converter = CreateMultiSearchDeserializer(p);
					var serializer = ConnectionSettings.CreateStateful(converter);
					var creator = new MultiSearchCreator((r, s) => serializer.Deserialize<MultiSearchResponse>(s));
					request.RequestParameters.DeserializationOverride = creator;
					return LowLevelDispatch.MsearchDispatch<MultiSearchResponse>(p, new SerializableData<IMultiSearchRequest>(p));
				}
			);

		/// <inheritdoc />
		public Task<IMultiSearchResponse> MultiSearchAsync(Func<MultiSearchDescriptor, IMultiSearchRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			MultiSearchAsync(selector?.Invoke(new MultiSearchDescriptor()), cancellationToken);


		/// <inheritdoc />
		public Task<IMultiSearchResponse> MultiSearchAsync(IMultiSearchRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) => Dispatcher.DispatchAsync<IMultiSearchRequest, MultiSearchRequestParameters, MultiSearchResponse, IMultiSearchResponse>(
			request,
			cancellationToken,
			(p, d, c) =>
			{
				var converter = CreateMultiSearchDeserializer(p);
				var serializer = ConnectionSettings.CreateStateful(converter);
				var creator = new MultiSearchCreator((r, s) => serializer.Deserialize<MultiSearchResponse>(s));
				request.RequestParameters.DeserializationOverride = creator;
				return LowLevelDispatch.MsearchDispatchAsync<MultiSearchResponse>(p, new SerializableData<IMultiSearchRequest>(p), c);
			}
		);

		private JsonConverter CreateMultiSearchDeserializer(IMultiSearchRequest request) =>
			new MultiSearchResponseJsonConverter(ConnectionSettings, request);
	}
}
