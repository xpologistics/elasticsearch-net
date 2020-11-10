﻿using System;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<CountRequest>))]
	public partial interface ICountRequest
	{
		[JsonProperty("query")]
		QueryContainer Query { get; set; }
	}

	public partial interface ICountRequest<T> : ICountRequest
		where T : class { }

	public partial class CountRequest
	{
		public QueryContainer Query { get; set; }

		protected override HttpMethod HttpMethod =>
			Self.RequestParameters.ContainsQueryString("source") || Self.RequestParameters.ContainsQueryString("q") || Self.Query == null
			|| Self.Query.IsConditionless()
				? HttpMethod.GET
				: HttpMethod.POST;
	}

	public partial class CountRequest<T>
	{
		public QueryContainer Query { get; set; }

		protected override HttpMethod HttpMethod =>
			Self.RequestParameters.ContainsQueryString("source") || Self.RequestParameters.ContainsQueryString("q") || Self.Query == null
			|| Self.Query.IsConditionless()
				? HttpMethod.GET
				: HttpMethod.POST;
	}

	[DescriptorFor("Count")]
	public partial class CountDescriptor<T> where T : class
	{
		protected override HttpMethod HttpMethod =>
			Self.RequestParameters.ContainsQueryString("source") || Self.RequestParameters.ContainsQueryString("q") || Self.Query == null
			|| Self.Query.IsConditionless()
				? HttpMethod.GET
				: HttpMethod.POST;

		QueryContainer ICountRequest.Query { get; set; }

		public CountDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> querySelector) =>
			Assign(querySelector, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<T>()));
	}
}
