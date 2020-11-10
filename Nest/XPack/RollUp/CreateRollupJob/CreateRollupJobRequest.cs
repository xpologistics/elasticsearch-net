﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// This API enables you to create a rollup job. The job will be created in a STOPPED state, and must be started with the Start Job API.
	/// <para>You must have manage or manage_rollup cluster privileges to use this API.</para>
	/// </summary>
	[MapsApi("xpack.rollup.put_job.json")]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<CreateRollupJobRequest>))]
	public partial interface ICreateRollupJobRequest
	{
		/// <summary> A cron string which defines when the rollup job should be executed. </summary>
		[JsonProperty("cron")]
		string Cron { get; set; }

		/// <summary> Defines the grouping fields that are defined for this rollup job </summary>
		[JsonProperty("groups")]
		IRollupGroupings Groups { get; set; }

		/// <summary> The index, or index pattern, that you wish to rollup. Supports wildcard-style patterns (logstash-*). </summary>
		[JsonProperty("index_pattern")]
		string IndexPattern { get; set; }

		/// <summary> Defines the metrics that should be collected for each grouping tuple </summary>
		[JsonProperty("metrics")]
		IEnumerable<IRollupFieldMetric> Metrics { get; set; }

		/// <summary>
		/// The number of bucket results that should be processed on each iteration of the rollup indexer.
		/// A larger value will tend to execute faster, but will require more memory during processing.
		/// </summary>
		[JsonProperty("page_size")]
		long? PageSize { get; set; }

		/// <summary> The index that you wish to store rollup results into. Can be shared with other rollup jobs. </summary>
		[JsonProperty("rollup_index")]
		IndexName RollupIndex { get; set; }
	}

	/// <inheritdoc cref="ICreateRollupJobRequest" />
	public partial class CreateRollupJobRequest
	{
		/// <inheritdoc cref="ICreateRollupJobRequest.Cron">
		public string Cron { get; set; }

		/// <inheritdoc cref="ICreateRollupJobRequest.Groups">
		public IRollupGroupings Groups { get; set; }

		/// <inheritdoc cref="ICreateRollupJobRequest.IndexPattern">
		public string IndexPattern { get; set; }

		/// <inheritdoc cref="ICreateRollupJobRequest.Metrics">
		public IEnumerable<IRollupFieldMetric> Metrics { get; set; }

		/// <inheritdoc cref="ICreateRollupJobRequest.PageSize">
		public long? PageSize { get; set; }

		/// <inheritdoc cref="ICreateRollupJobRequest.RollupIndex">
		public IndexName RollupIndex { get; set; }
	}

	/// <inheritdoc cref="ICreateRollupJobRequest" />
	/// >
	public partial class CreateRollupJobDescriptor<T> where T : class
	{
		string ICreateRollupJobRequest.Cron { get; set; }
		IRollupGroupings ICreateRollupJobRequest.Groups { get; set; }
		string ICreateRollupJobRequest.IndexPattern { get; set; }
		IEnumerable<IRollupFieldMetric> ICreateRollupJobRequest.Metrics { get; set; }
		long? ICreateRollupJobRequest.PageSize { get; set; }
		IndexName ICreateRollupJobRequest.RollupIndex { get; set; }

		/// <inheritdoc cref="ICreateRollupJobRequest.IndexPattern">
		public CreateRollupJobDescriptor<T> IndexPattern(string indexPattern) => Assign(indexPattern, (a, v) => a.IndexPattern = v);

		/// <inheritdoc cref="ICreateRollupJobRequest.RollupIndex">
		public CreateRollupJobDescriptor<T> RollupIndex(IndexName index) => Assign(index, (a, v) => a.RollupIndex = v);

		/// <inheritdoc cref="ICreateRollupJobRequest.Cron">
		public CreateRollupJobDescriptor<T> Cron(string cron) => Assign(cron, (a, v) => a.Cron = v);

		/// <inheritdoc cref="ICreateRollupJobRequest.PageSize">
		public CreateRollupJobDescriptor<T> PageSize(long? pageSize) => Assign(pageSize, (a, v) => a.PageSize = v);

		/// <inheritdoc cref="ICreateRollupJobRequest.Groups">
		public CreateRollupJobDescriptor<T> Groups(Func<RollupGroupingsDescriptor<T>, IRollupGroupings> selector) =>
			Assign(selector, (a, v) => a.Groups = v?.Invoke(new RollupGroupingsDescriptor<T>()));

		/// <inheritdoc cref="ICreateRollupJobRequest.Metrics">
		public CreateRollupJobDescriptor<T> Metrics(Func<RollupFieldMetricsDescriptor<T>, IPromise<IList<IRollupFieldMetric>>> selector) =>
			Assign(selector, (a, v) => a.Metrics = v?.Invoke(new RollupFieldMetricsDescriptor<T>())?.Value);
	}
}
