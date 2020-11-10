﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A request to put an alias to one or more indices
	/// </summary>
	public partial interface IPutAliasRequest
	{
		/// <inheritdoc cref="IAlias.Filter"/>
		[JsonProperty("filter")]
		QueryContainer Filter { get; set; }

		/// <inheritdoc cref="IAlias.IndexRouting"/>
		[JsonProperty("index_routing")]
		Routing IndexRouting { get; set; }

		/// <inheritdoc cref="IAlias.IsWriteIndex" />
		[JsonProperty("is_write_index")]
		bool? IsWriteIndex { get; set; }

		/// <inheritdoc cref="IAlias.Routing"/>
		[JsonProperty("routing")]
		Routing Routing { get; set; }

		/// <inheritdoc cref="IAlias.SearchRouting"/>
		[JsonProperty("search_routing")]
		Routing SearchRouting { get; set; }
	}

	/// <inheritdoc cref="IPutAliasRequest"/>
	public partial class PutAliasRequest
	{
		/// <inheritdoc cref="IPutAliasRequest.Filter"/>
		public QueryContainer Filter { get; set; }
		/// <inheritdoc cref="IPutAliasRequest.IndexRouting"/>
		public Routing IndexRouting { get; set; }
		/// <inheritdoc cref="IPutAliasRequest.IsWriteIndex" />
		public bool? IsWriteIndex { get; set; }
		/// <inheritdoc cref="IPutAliasRequest.Routing"/>
		public Routing Routing { get; set; }
		/// <inheritdoc cref="IPutAliasRequest.SearchRouting"/>
		public Routing SearchRouting { get; set; }
	}

	/// <inheritdoc cref="IPutAliasRequest"/>
	[DescriptorFor("IndicesPutAlias")]
	public partial class PutAliasDescriptor
	{
		QueryContainer IPutAliasRequest.Filter { get; set; }
		Routing IPutAliasRequest.IndexRouting { get; set; }
		bool? IPutAliasRequest.IsWriteIndex { get; set; }
		Routing IPutAliasRequest.Routing { get; set; }
		Routing IPutAliasRequest.SearchRouting { get; set; }

		/// <inheritdoc cref="IPutAliasRequest.Routing"/>
		public PutAliasDescriptor Routing(Routing routing) => Assign(routing, (a, v) => a.Routing = v);

		/// <inheritdoc cref="IPutAliasRequest.IndexRouting"/>
		public PutAliasDescriptor IndexRouting(Routing routing) => Assign(routing, (a, v) => a.IndexRouting = v);

		/// <inheritdoc cref="IPutAliasRequest.SearchRouting"/>
		public PutAliasDescriptor SearchRouting(Routing routing) => Assign(routing, (a, v) => a.SearchRouting = v);

		/// <inheritdoc cref="IPutAliasRequest.IsWriteIndex" />
		public PutAliasDescriptor IsWriteIndex(bool? isWriteIndex = true) => Assign(isWriteIndex, (a, v) => a.IsWriteIndex = v);

		/// <inheritdoc cref="IPutAliasRequest.Filter"/>
		public PutAliasDescriptor Filter<T>(Func<QueryContainerDescriptor<T>, QueryContainer> filterSelector) where T : class =>
			Assign(filterSelector, (a, v) => a.Filter = v?.Invoke(new QueryContainerDescriptor<T>()));
	}
}
