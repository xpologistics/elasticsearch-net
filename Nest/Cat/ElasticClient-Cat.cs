﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest6
{
	public partial class ElasticClient
	{
		private CatResponse<TCatRecord> DeserializeCatResponse<TCatRecord>(IApiCallDetails response, Stream stream)
			where TCatRecord : ICatRecord
		{
			var catResponse = new CatResponse<TCatRecord>();

			if (!response.Success) return catResponse;

			var records = RequestResponseSerializer.Deserialize<IReadOnlyCollection<TCatRecord>>(stream);
			catResponse.Records = records;

			return catResponse;
		}

		private ICatResponse<TCatRecord> DoCat<TRequest, TParams, TCatRecord>(
			TRequest request,
			Func<IRequest<TParams>, CatResponse<TCatRecord>> dispatch
		)
			where TCatRecord : ICatRecord
			where TParams : RequestParameters<TParams>, new()
			where TRequest : IRequest<TParams> =>
			Dispatcher.Dispatch<TRequest, TParams, CatResponse<TCatRecord>>(
				ForceConfiguration<TRequest, TParams>(request, c =>
				{
					c.Accept = RequestData.MimeType;
					c.ContentType = RequestData.MimeType;
				}),
				new Func<IApiCallDetails, Stream, CatResponse<TCatRecord>>(DeserializeCatResponse<TCatRecord>),
				(p, d) => dispatch(p)
			);

		private Task<ICatResponse<TCatRecord>> DoCatAsync<TRequest, TParams, TCatRecord>(
			TRequest request,
			CancellationToken cancellationToken,
			Func<IRequest<TParams>, CancellationToken, Task<CatResponse<TCatRecord>>> dispatch
		)
			where TCatRecord : ICatRecord
			where TParams : RequestParameters<TParams>, new()
			where TRequest : IRequest<TParams> =>
			Dispatcher.DispatchAsync<TRequest, TParams, CatResponse<TCatRecord>, ICatResponse<TCatRecord>>(
				ForceConfiguration<TRequest, TParams>(request, c =>
				{
					c.Accept = RequestData.MimeType;
					c.ContentType = RequestData.MimeType;
				}),
				cancellationToken,
				new Func<IApiCallDetails, Stream, CatResponse<TCatRecord>>(DeserializeCatResponse<TCatRecord>),
				(p, d, c) => dispatch(p, c)
			);
	}
}
