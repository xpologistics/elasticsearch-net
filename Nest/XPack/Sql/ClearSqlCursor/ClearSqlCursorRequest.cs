﻿using Newtonsoft.Json;

namespace Nest6
{
	[MapsApi("xpack.sql.clear_cursor.json")]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<ClearSqlCursorRequest>))]
	public partial interface IClearSqlCursorRequest
	{
		/// <summary>
		/// <para>
		/// You’ve reached the last page when there is no cursor returned in the results. Like Elasticsearch’s scroll,
		/// SQL may keep state in Elasticsearch to support the cursor.
		/// Unlike scroll, receiving the last page is enough to guarantee that the Elasticsearch state is cleared.
		/// </para>
		/// </summary>
		[JsonProperty("cursor")]
		string Cursor { get; set; }
	}

	public partial class ClearSqlCursorRequest
	{
		/// <inheritdoc cref="IQuerySqlRequest.Cursor" />
		/// >
		public string Cursor { get; set; }
	}

	public partial class ClearSqlCursorDescriptor
	{
		string IClearSqlCursorRequest.Cursor { get; set; }

		/// <inheritdoc cref="IQuerySqlRequest.Cursor" />
		/// >
		public ClearSqlCursorDescriptor Cursor(string cursor) => Assign(cursor, (a, v) => a.Cursor = v);
	}
}
