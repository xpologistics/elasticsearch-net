﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Checks each suggestion against the specified query to prune suggestions
	/// for which no matching docs exist in the index.
	/// </summary>
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<PhraseSuggestCollate>))]
	public interface IPhraseSuggestCollate
	{
		/// <summary>
		/// The parameters for the query. the suggestion value will be added to the variables you specify.
		/// </summary>
		[JsonProperty("params")]
		IDictionary<string, object> Params { get; set; }

		/// <summary>
		/// Controls if all phrase suggestions will be returned. When set to <c>true</c>, the suggestions will have
		/// an additional option collate_match, which will be <c>true</c> if matching documents for the phrase was found,
		/// <c>false</c> otherwise. The default value for <see cref="Prune" /> is <c>false</c>.
		/// </summary>
		[JsonProperty("prune")]
		bool? Prune { get; set; }

		/// <summary>
		/// The collate query to run.
		/// </summary>
		[JsonProperty("query")]
		IPhraseSuggestCollateQuery Query { get; set; }
	}

	/// <inheritdoc />
	public class PhraseSuggestCollate : IPhraseSuggestCollate
	{
		/// <inheritdoc />
		public IDictionary<string, object> Params { get; set; }

		/// <inheritdoc />
		public bool? Prune { get; set; }

		/// <inheritdoc />
		public IPhraseSuggestCollateQuery Query { get; set; }
	}

	public class PhraseSuggestCollateDescriptor<T> : DescriptorBase<PhraseSuggestCollateDescriptor<T>, IPhraseSuggestCollate>, IPhraseSuggestCollate
		where T : class
	{
		IDictionary<string, object> IPhraseSuggestCollate.Params { get; set; }
		bool? IPhraseSuggestCollate.Prune { get; set; }
		IPhraseSuggestCollateQuery IPhraseSuggestCollate.Query { get; set; }

		/// <summary>
		/// The collate query to run
		/// </summary>
		public PhraseSuggestCollateDescriptor<T> Query(Func<PhraseSuggestCollateQueryDescriptor, IPhraseSuggestCollateQuery> selector) =>
			Assign(selector, (a, v) => a.Query = v?.Invoke(new PhraseSuggestCollateQueryDescriptor()));

		/// <summary>
		/// Controls if all phrase suggestions will be returned. When set to <c>true</c>, the suggestions will have
		/// an additional option collate_match, which will be <c>true</c> if matching documents for the phrase was found,
		/// <c>false</c> otherwise. The default value for <see cref="Prune" /> is <c>false</c>.
		/// </summary>
		public PhraseSuggestCollateDescriptor<T> Prune(bool? prune = true) => Assign(prune, (a, v) => a.Prune = v);

		/// <summary>
		/// The parameters for the query. the suggestion value will be added to the variables you specify.
		/// </summary>
		public PhraseSuggestCollateDescriptor<T> Params(IDictionary<string, object> paramsDictionary) => Assign(paramsDictionary, (a, v) => a.Params = v);

		/// <summary>
		/// The parameters for the query. the suggestion value will be added to the variables you specify.
		/// </summary>
		public PhraseSuggestCollateDescriptor<T> Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> paramsDictionary) =>
			Assign(paramsDictionary(new FluentDictionary<string, object>()), (a, v) => a.Params = v);
	}
}
