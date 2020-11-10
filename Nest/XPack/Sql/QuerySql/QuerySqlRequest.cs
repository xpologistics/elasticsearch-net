﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[MapsApi("xpack.sql.query.json")]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<QuerySqlRequest>))]
	public partial interface IQuerySqlRequest : ISqlRequest
	{
		/// <summary>
		/// Continue to the next page by sending back the cursor field returned in the previous response.
		/// <para>
		/// You’ve reached the last page when there is no cursor returned in the results. Like Elasticsearch’s scroll,
		/// SQL may keep state in Elasticsearch to support the cursor.
		/// Unlike scroll, receiving the last page is enough to guarantee that the Elasticsearch state is cleared.
		/// </para>
		/// </summary>
		[JsonProperty("cursor")]
		string Cursor { get; set; }
	}

	public partial class QuerySqlRequest
	{
		/// <inheritdoc cref="IQuerySqlRequest.Cursor" />
		/// >
		public string Cursor { get; set; }

		/// <inheritdoc cref="ISqlRequest.FetchSize" />
		/// >
		public int? FetchSize { get; set; }

		/// <inheritdoc cref="ISqlRequest.Filter" />
		/// >
		public QueryContainer Filter { get; set; }

		/// <inheritdoc cref="ISqlRequest.Query" />
		/// >
		public string Query { get; set; }

		/// <inheritdoc cref="ISqlRequest.TimeZone" />
		/// >
		public string TimeZone { get; set; }
	}

	public partial class QuerySqlDescriptor
	{
		string IQuerySqlRequest.Cursor { get; set; }
		int? ISqlRequest.FetchSize { get; set; }
		QueryContainer ISqlRequest.Filter { get; set; }
		string ISqlRequest.Query { get; set; }
		string ISqlRequest.TimeZone { get; set; }

		/// <inheritdoc cref="ISqlRequest.Query" />
		/// >
		public QuerySqlDescriptor Query(string query) => Assign(query, (a, v) => a.Query = v);

		/// <inheritdoc cref="ISqlRequest.TimeZone" />
		/// >
		public QuerySqlDescriptor TimeZone(string timeZone) => Assign(timeZone, (a, v) => a.TimeZone = v);

		/// <inheritdoc cref="ISqlRequest.FetchSize" />
		/// >
		public QuerySqlDescriptor FetchSize(int? fetchSize) => Assign(fetchSize, (a, v) => a.FetchSize = v);

		/// <inheritdoc cref="ISqlRequest.Filter" />
		/// >
		public QuerySqlDescriptor Filter<T>(Func<QueryContainerDescriptor<T>, QueryContainer> querySelector)
			where T : class => Assign(querySelector, (a, v) => a.Filter = v?.Invoke(new QueryContainerDescriptor<T>()));

		/// <inheritdoc cref="IQuerySqlRequest.Cursor" />
		/// >
		public QuerySqlDescriptor Cursor(string cursor) => Assign(cursor, (a, v) => a.Cursor = v);
	}
}
