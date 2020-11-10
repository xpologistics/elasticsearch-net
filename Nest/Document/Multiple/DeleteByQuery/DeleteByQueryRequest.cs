﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Delete documents that match a given query
	/// </summary>
	public partial interface IDeleteByQueryRequest
	{
		/// <summary>
		/// The query to use to select documents for deletion
		/// </summary>
		[JsonProperty("query")]
		QueryContainer Query { get; set; }

		/// <summary>
		/// Parallelize the deleting process. This parallelization can improve efficiency and
		/// provide a convenient way to break the request down into smaller parts.
		/// </summary>
		[JsonProperty("slice")]
		ISlicedScroll Slice { get; set; }
	}

	/// <inheritdoc />
	public interface IDeleteByQueryRequest<T> : IDeleteByQueryRequest where T : class { }

	/// <inheritdoc cref="IDeleteByQueryRequest" />
	public partial class DeleteByQueryRequest
	{
		/// <inheritdoc />
		public QueryContainer Query { get; set; }

		/// <inheritdoc />
		public ISlicedScroll Slice { get; set; }
	}

	/// <inheritdoc cref="IDeleteByQueryRequest" />
	public partial class DeleteByQueryRequest<T> : IDeleteByQueryRequest<T>
		where T : class
	{
		public DeleteByQueryRequest() : this(typeof(T), typeof(T)) { }

		/// <inheritdoc />
		public QueryContainer Query { get; set; }

		/// <inheritdoc />
		public ISlicedScroll Slice { get; set; }
	}

	/// <inheritdoc cref="IDeleteByQueryRequest" />
	public partial class DeleteByQueryDescriptor<T> : IDeleteByQueryRequest<T>
		where T : class
	{
		QueryContainer IDeleteByQueryRequest.Query { get; set; }
		ISlicedScroll IDeleteByQueryRequest.Slice { get; set; }

		/// <summary>
		/// A match_all query to select all documents. Convenient shorthand for specifying
		/// a match_all query using <see cref="Query" />
		/// </summary>
		public DeleteByQueryDescriptor<T> MatchAll() => Assign(new QueryContainerDescriptor<T>().MatchAll(), (a, v) => a.Query = v);

		/// <summary>
		/// The query to use to select documents for deletion
		/// </summary>
		public DeleteByQueryDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> querySelector) =>
			Assign(querySelector, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<T>()));

		/// <summary>
		/// Parallelize the deleting process. This parallelization can improve efficiency and
		/// provide a convenient way to break the request down into smaller parts.
		/// </summary>
		public DeleteByQueryDescriptor<T> Slice(Func<SlicedScrollDescriptor<T>, ISlicedScroll> selector) =>
			Assign(selector, (a, v) => a.Slice = v?.Invoke(new SlicedScrollDescriptor<T>()));
	}
}
