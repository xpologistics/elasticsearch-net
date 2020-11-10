﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A response to a search request
	/// </summary>
	/// <typeparam name="T">The document type</typeparam>
	public interface ISearchResponse<T> : IResponse where T : class
	{
		/// <summary>
		/// Gets the collection of aggregations
		/// </summary>
		AggregateDictionary Aggregations { get; }

		/// <inheritdoc cref="Aggregations"/>
		[Obsolete("Aggs has been renamed to Aggregations and will be removed in NEST 7.x")]
		AggregateDictionary Aggs { get; }

		/// <summary>
		/// Gets the statistics about the clusters on which the search query was executed.
		/// </summary>
		/// <remarks>
		/// Valid for cross cluster searches and Elasticsearch 6.1.0+
		/// </remarks>
		ClusterStatistics Clusters { get; }

		/// <summary>
		/// Gets the documents inside the hits, by deserializing <see cref="IHitMetadata{T}.Source" /> into T.
		/// <para>
		/// NOTE: if you use <see cref="ISearchRequest.StoredFields" /> on the search request,
		/// <see cref="Documents" /> will be empty and you should use <see cref="Fields" />
		/// instead to get the field values. As an alternative to
		/// <see cref="Fields" />, try source filtering using <see cref="ISearchRequest.Source" /> on the
		/// search request to return <see cref="Documents" /> with partial fields selected
		/// </para>
		/// </summary>
		IReadOnlyCollection<T> Documents { get; }

		/// <summary>
		/// Gets the field values inside the hits, when the search request uses
		/// <see cref="SearchRequest{T}.StoredFields" />.
		/// </summary>
		IReadOnlyCollection<FieldValues> Fields { get; }

		/// <summary>
		/// Gets the collection of hits that matched the query
		/// </summary>
		/// <value>
		/// The hits.
		/// </value>
		IReadOnlyCollection<IHit<T>> Hits { get; }

		/// <summary>
		/// Gets the meta data about the hits that match the search query criteria.
		/// </summary>
		HitsMetadata<T> HitsMetadata { get; }

		/// <summary>
		/// Gets the maximum score for documents matching the search query criteria
		/// </summary>
		double MaxScore { get; }

		/// <summary>
		/// Number of times the server performed an incremental reduce phase
		/// </summary>
		long NumberOfReducePhases { get; }

		/// <summary>
		/// Gets the results of profiling the search query. Has a value only when
		/// <see cref="ISearchRequest.Profile" /> is set to <c>true</c> on the search request.
		/// </summary>
		Profile Profile { get; }

		/// <summary>
		/// Gets the scroll id which can be passed to the Scroll API in order to retrieve the next batch
		/// of results. Has a value only when <see cref="SearchRequest{T}.Scroll" /> is specified on the
		/// search request
		/// </summary>
		string ScrollId { get; }

		/// <summary>
		/// Gets the statistics about the shards on which the search query was executed.
		/// </summary>
		ShardStatistics Shards { get; }

		/// <summary>
		/// Gets the suggester results.
		/// </summary>
		SuggestDictionary<T> Suggest { get; }

		/// <summary>
		/// Gets a value indicating whether the search was terminated early
		/// </summary>
		bool TerminatedEarly { get; }

		/// <summary>
		/// Gets a value indicating whether the search timed out or not
		/// </summary>
		bool TimedOut { get; }

		/// <summary>
		/// Time in milliseconds for Elasticsearch to execute the search
		/// </summary>
		long Took { get; }

		/// <summary>
		/// Gets the total number of documents matching the search query criteria
		/// </summary>
		long Total { get; }
	}

	/// <inheritdoc cref="ISearchResponse{T}"/>
	[JsonObject]
	public class SearchResponse<T> : ResponseBase, ISearchResponse<T> where T : class
	{
		private IReadOnlyCollection<T> _documents;
		private IReadOnlyCollection<FieldValues> _fields;
		private IReadOnlyCollection<IHit<T>> _hits;

		/// <inheritdoc />
		[JsonProperty("aggregations")]
		public AggregateDictionary Aggregations { get; internal set; } = AggregateDictionary.Default;

		/// <inheritdoc />
		[JsonIgnore]
		public AggregateDictionary Aggs => Aggregations;

		/// <inheritdoc />
		[JsonProperty("_clusters")]
		public ClusterStatistics Clusters { get; internal set; }

		/// <inheritdoc />
		[JsonIgnore]
		public IReadOnlyCollection<T> Documents =>
			_documents ?? (_documents = Hits
				.Select(h => h.Source)
				.ToList());

		/// <inheritdoc />
		public IReadOnlyCollection<FieldValues> Fields =>
			_fields ?? (_fields = Hits
				.Select(h => h.Fields)
				.ToList());

		/// <inheritdoc />
		[JsonIgnore]
		public IReadOnlyCollection<IHit<T>> Hits =>
			_hits ?? (_hits = HitsMetadata?.Hits ?? EmptyReadOnly<IHit<T>>.Collection);

		/// <inheritdoc />
		[JsonProperty("hits")]
		public HitsMetadata<T> HitsMetadata { get; internal set; }

		/// <inheritdoc />
		[JsonIgnore]
		public double MaxScore => HitsMetadata?.MaxScore ?? 0;

		/// <inheritdoc />
		[JsonProperty("num_reduce_phases")]
		public long NumberOfReducePhases { get; internal set; }

		/// <inheritdoc />
		[JsonProperty("profile")]
		public Profile Profile { get; internal set; }

		/// <inheritdoc />
		[JsonProperty("_scroll_id")]
		public string ScrollId { get; internal set; }

		/// <inheritdoc />
		[JsonProperty("_shards")]
		public ShardStatistics Shards { get; internal set; }

		/// <inheritdoc />
		[JsonProperty("suggest")]
		public SuggestDictionary<T> Suggest { get; internal set; } = SuggestDictionary<T>.Default;

		/// <inheritdoc />
		[JsonProperty("terminated_early")]
		public bool TerminatedEarly { get; internal set; }

		/// <inheritdoc />
		[JsonProperty("timed_out")]
		public bool TimedOut { get; internal set; }

		/// <inheritdoc />
		[JsonProperty("took")]
		public long Took { get; internal set; }

		/// <inheritdoc />
		[JsonIgnore]
		public long Total => HitsMetadata?.Total ?? 0;
	}
}
