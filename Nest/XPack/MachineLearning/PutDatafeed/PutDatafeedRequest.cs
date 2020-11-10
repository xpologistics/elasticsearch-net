﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Creates a datafeed for a machine learning job.
	/// </summary>
	public partial interface IPutDatafeedRequest
	{
		/// <summary>
		/// If set, the datafeed performs aggregation searches.
		/// </summary>
		[JsonProperty("aggregations")]
		AggregationDictionary Aggregations { get; set; }

		/// <summary>
		/// Specifies how data searches are split into time chunks.
		/// </summary>
		[JsonProperty("chunking_config")]
		IChunkingConfig ChunkingConfig { get; set; }

		/// <summary>
		/// The interval at which scheduled queries are made while the datafeed runs in real time.
		/// The default value is either the bucket span for short bucket spans, or, for longer bucket spans,
		/// a sensible fraction of the bucket span.
		/// </summary>
		[JsonProperty("frequency")]
		Time Frequency { get; set; }

		/// <summary>
		///  A list of index names to search within, wildcards are supported.
		/// </summary>
		[JsonProperty("indices")]
		[JsonConverter(typeof(IndicesJsonConverter))]
		Indices Indices { get; set; }

		/// <summary>
		/// A numerical character string that uniquely identifies the job.
		/// </summary>
		[JsonProperty("job_id")]
		Id JobId { get; set; }

		/// <summary>
		/// Describe the query to perform using a query descriptor lambda.
		/// </summary>
		[JsonProperty("query")]
		QueryContainer Query { get; set; }

		/// <summary>
		/// The number of seconds behind real time that data is queried.
		/// For example, if data from 10:04 a.m. might not be searchable until 10:06 a.m.,
		/// set this property to 120 seconds. The default value is 60s.
		/// </summary>
		[JsonProperty("query_delay")]
		Time QueryDelay { get; set; }

		/// <summary>
		/// Specifies scripts that evaluate custom expressions and returns script fields to the datafeed.
		/// The detector configuration in a job can contain functions that use these script fields.
		/// </summary>
		[JsonProperty("script_fields")]
		IScriptFields ScriptFields { get; set; }

		/// <summary>
		/// The size parameter that is used in Elasticsearch searches.
		/// </summary>
		[JsonProperty("scroll_size")]
		int? ScrollSize { get; set; }

		/// <summary>
		///  A list of types to search for within the specified indices.
		/// </summary>
		[JsonProperty("types")]
		[JsonConverter(typeof(TypesJsonConverter))]
		Types Types { get; set; }
	}

	/// <inheritdoc />
	public partial class PutDatafeedRequest
	{
		/// <inheritdoc />
		public AggregationDictionary Aggregations { get; set; }

		/// <inheritdoc />
		public IChunkingConfig ChunkingConfig { get; set; }

		/// <inheritdoc />
		public Time Frequency { get; set; }

		/// <inheritdoc />
		public Indices Indices { get; set; }

		/// <inheritdoc />
		public Id JobId { get; set; }

		/// <inheritdoc />
		public QueryContainer Query { get; set; }

		/// <inheritdoc />
		public Time QueryDelay { get; set; }

		/// <inheritdoc />
		public IScriptFields ScriptFields { get; set; }

		/// <inheritdoc />
		public int? ScrollSize { get; set; }

		/// <inheritdoc />
		public Types Types { get; set; }
	}

	[DescriptorFor("XpackMlPutDatafeed")]
	public partial class PutDatafeedDescriptor<T> where T : class
	{
		AggregationDictionary IPutDatafeedRequest.Aggregations { get; set; }
		IChunkingConfig IPutDatafeedRequest.ChunkingConfig { get; set; }
		Time IPutDatafeedRequest.Frequency { get; set; }
		Indices IPutDatafeedRequest.Indices { get; set; }
		Id IPutDatafeedRequest.JobId { get; set; }
		QueryContainer IPutDatafeedRequest.Query { get; set; }
		Time IPutDatafeedRequest.QueryDelay { get; set; }
		IScriptFields IPutDatafeedRequest.ScriptFields { get; set; }
		int? IPutDatafeedRequest.ScrollSize { get; set; }
		Types IPutDatafeedRequest.Types { get; set; }

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> Aggregations(Func<AggregationContainerDescriptor<T>, IAggregationContainer> aggregationsSelector) =>
			Assign(aggregationsSelector(new AggregationContainerDescriptor<T>())?.Aggregations, (a, v) => a.Aggregations = v);

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> ChunkingConfig(Func<ChunkingConfigDescriptor, IChunkingConfig> selector) =>
			Assign(selector, (a, v) => a.ChunkingConfig = v?.Invoke(new ChunkingConfigDescriptor()));

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> Frequency(Time frequency) => Assign(frequency, (a, v) => a.Frequency = v);

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> Indices(Indices indices) => Assign(indices, (a, v) => a.Indices = v);

		///<summary>a shortcut into calling Indices(typeof(TOther))</summary>
		public PutDatafeedDescriptor<T> Indices<TOther>() => Assign(typeof(TOther), (a, v) => a.Indices = v);

		///<summary>A shortcut into calling Indices(Indices.All)</summary>
		public PutDatafeedDescriptor<T> AllIndices() => Indices(Nest6.Indices.All);

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> JobId(Id jobId) => Assign(jobId, (a, v) => a.JobId = v);

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> query) =>
			Assign(query, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<T>()));

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> QueryDelay(Time queryDelay) => Assign(queryDelay, (a, v) => a.QueryDelay = v);

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> ScriptFields(Func<ScriptFieldsDescriptor, IPromise<IScriptFields>> selector) =>
			Assign(selector, (a, v) => a.ScriptFields = v?.Invoke(new ScriptFieldsDescriptor())?.Value);

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> ScrollSize(int? scrollSize) => Assign(scrollSize, (a, v) => a.ScrollSize = v);

		/// <inheritdoc />
		public PutDatafeedDescriptor<T> Types(Types types) => Assign(types, (a, v) => a.Types = v);

		///<summary>a shortcut into calling Types(typeof(TOther))</summary>
		public PutDatafeedDescriptor<T> Types<TOther>() => Assign(typeof(TOther), (a, v) => a.Types = v);

		///<summary>a shortcut into calling Types(Types.All)</summary>
		public PutDatafeedDescriptor<T> AllTypes() => Types(Nest6.Types.All);
	}
}
