﻿using System;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// An operation to define the calculation of
	/// term vectors when using Multi termvectors API
	/// </summary>
	public interface IMultiTermVectorOperation
	{
		/// <summary>
		/// A document not indexed in Elasticsearch,
		/// to generate term vectors for
		/// </summary>
		[JsonProperty("doc")]
		[JsonConverter(typeof(SourceConverter))]
		object Document { get; set; }

		/// <summary>
		/// Whether to include field statistics. When set to <c>false</c>,
		/// <para />
		/// - document count (how many documents contain this field)
		/// <para />
		/// - sum of document frequencies (the sum of document frequencies for all terms in this field)
		/// <para />
		/// - sum of total term frequencies (the sum of total term frequencies of each term in this field)
		/// <para />
		/// will be omitted. Default is <c>true</c>.
		/// </summary>
		[JsonProperty("field_statistics")]
		bool? FieldStatistics { get; set; }

		/// <summary>
		/// Filter terms based on their tf-idf scores.
		/// This can be useful in order find out a good characteristic
		/// vector of a document.
		/// </summary>
		[JsonProperty("filter")]
		ITermVectorFilter Filter { get; set; }

		/// <summary>
		/// The id of the document
		/// </summary>
		[JsonProperty("_id")]
		Id Id { get; set; }

		/// <summary>
		/// The index in which the document resides
		/// </summary>
		[JsonProperty("_index")]
		IndexName Index { get; set; }

		/// <summary>
		/// Whether to include the start and end offsets.
		/// Default is <c>true</c>.
		/// </summary>
		[JsonProperty("offsets")]
		bool? Offsets { get; set; }

		/// <summary>
		/// Whether to include the term payloads as
		/// base64 encoded bytes. Default is <c>true</c>
		/// </summary>
		[JsonProperty("payloads")]
		bool? Payloads { get; set; }

		/// <summary>
		/// Whether to include the term positions.
		/// Default is <c>true</c>
		/// </summary>
		[JsonProperty("positions")]
		bool? Positions { get; set; }

		/// <summary>
		/// When requesting term vectors for <see cref="Document" />,
		/// a shard to get the statistics from is randomly selected.
		/// Use <see cref="Routing" /> only to hit a particular shard.
		/// </summary>
		[JsonProperty("routing")]
		Routing Routing { get; set; }

		/// <summary>
		/// The document field to generate term
		/// vectors for
		/// </summary>
		[JsonProperty("fields")]
		// TODO: Rename to Fields in 7.x
		Fields StoredFields { get; set; }

		/// <summary>
		/// Whether to include term statistics. When set to <c>true</c>,
		/// <para />
		/// - total term frequency (how often a term occurs in all documents)
		/// <para />
		/// - document frequency (the number of documents containing the current term)
		/// <para />
		/// will be returned. Default is <c>false</c> since
		/// term statistics can have a large performance impact.
		/// </summary>
		[JsonProperty("term_statistics")]
		bool? TermStatistics { get; set; }

		/// <summary>
		/// The type of the document
		/// </summary>
		[JsonProperty("_type")]
		TypeName Type { get; set; }

		/// <summary>
		/// The version number
		/// </summary>
		[JsonProperty("version")]
		long? Version { get; set; }

		/// <summary>
		/// The type of version
		/// </summary>
		[JsonProperty("version_type")]
		VersionType? VersionType { get; set; }
	}

	/// <inheritdoc />
	public class MultiTermVectorOperation<T> : IMultiTermVectorOperation
		where T : class
	{
		private Routing _routing;

		public MultiTermVectorOperation(Id id)
		{
			Id = id;
			Index = typeof(T);
			Type = typeof(T);
		}

		/// <inheritdoc />
		public object Document { get; set; }

		/// <inheritdoc />
		public bool? FieldStatistics { get; set; }

		/// <inheritdoc />
		public ITermVectorFilter Filter { get; set; }

		/// <inheritdoc />
		public Id Id { get; set; }

		/// <inheritdoc />
		public IndexName Index { get; set; }

		/// <inheritdoc />
		public bool? Offsets { get; set; }

		/// <inheritdoc />
		public bool? Payloads { get; set; }

		/// <inheritdoc />
		public bool? Positions { get; set; }

		/// <inheritdoc />
		public Routing Routing
		{
			get => _routing ?? (Document == null ? null : new Routing(Document));
			set => _routing = value;
		}

		/// <inheritdoc />
		public Fields StoredFields { get; set; }

		/// <inheritdoc />
		public bool? TermStatistics { get; set; }

		/// <inheritdoc />
		public TypeName Type { get; set; }

		/// <inheritdoc />
		public long? Version { get; set; }

		/// <inheritdoc />
		public VersionType? VersionType { get; set; }
	}

	/// <inheritdoc cref="IMultiTermVectorOperation" />
	public class MultiTermVectorOperationDescriptor<T>
		: DescriptorBase<MultiTermVectorOperationDescriptor<T>, IMultiTermVectorOperation>, IMultiTermVectorOperation
		where T : class
	{
		private Routing _routing;
		object IMultiTermVectorOperation.Document { get; set; }
		bool? IMultiTermVectorOperation.FieldStatistics { get; set; }
		ITermVectorFilter IMultiTermVectorOperation.Filter { get; set; }
		Id IMultiTermVectorOperation.Id { get; set; }

		IndexName IMultiTermVectorOperation.Index { get; set; } = typeof(T);
		bool? IMultiTermVectorOperation.Offsets { get; set; }
		bool? IMultiTermVectorOperation.Payloads { get; set; }
		bool? IMultiTermVectorOperation.Positions { get; set; }

		Routing IMultiTermVectorOperation.Routing
		{
			get => _routing ?? (Self.Document == null ? null : new Routing(Self.Document));
			set => _routing = value;
		}

		Fields IMultiTermVectorOperation.StoredFields { get; set; }
		bool? IMultiTermVectorOperation.TermStatistics { get; set; }
		TypeName IMultiTermVectorOperation.Type { get; set; } = typeof(T);
		long? IMultiTermVectorOperation.Version { get; set; }
		VersionType? IMultiTermVectorOperation.VersionType { get; set; }

		/// <inheritdoc cref="IMultiTermVectorOperation.StoredFields" />
		// TODO: Rename to Fields in 7.x
		public MultiTermVectorOperationDescriptor<T> StoredFields(Func<FieldsDescriptor<T>, IPromise<Fields>> fields) =>
			Assign(fields, (a, v) => a.StoredFields = v?.Invoke(new FieldsDescriptor<T>())?.Value);

		/// <inheritdoc cref="IMultiTermVectorOperation.StoredFields" />
		// TODO: Rename to Fields in 7.x
		public MultiTermVectorOperationDescriptor<T> StoredFields(Fields fields) => Assign(fields, (a, v) => a.StoredFields = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Id" />
		public MultiTermVectorOperationDescriptor<T> Id(Id id) => Assign(id, (a, v) => a.Id = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Index" />
		public MultiTermVectorOperationDescriptor<T> Index(IndexName index) => Assign(index, (a, v) => a.Index = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Type" />
		public MultiTermVectorOperationDescriptor<T> Type(TypeName type) => Assign(type, (a, v) => a.Type = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Document" />
		public MultiTermVectorOperationDescriptor<T> Document(T document) => Assign(document, (a, v) => a.Document = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Offsets" />
		public MultiTermVectorOperationDescriptor<T> Offsets(bool? offsets = true) => Assign(offsets, (a, v) => a.Offsets = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Payloads" />
		public MultiTermVectorOperationDescriptor<T> Payloads(bool? payloads = true) => Assign(payloads, (a, v) => a.Payloads = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Positions" />
		public MultiTermVectorOperationDescriptor<T> Positions(bool? positions = true) => Assign(positions, (a, v) => a.Positions = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.TermStatistics" />
		public MultiTermVectorOperationDescriptor<T> TermStatistics(bool? termStatistics = true) => Assign(termStatistics, (a, v) => a.TermStatistics = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.FieldStatistics" />
		public MultiTermVectorOperationDescriptor<T> FieldStatistics(bool? fieldStatistics = true) =>
			Assign(fieldStatistics, (a, v) => a.FieldStatistics = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Filter" />
		public MultiTermVectorOperationDescriptor<T> Filter(Func<TermVectorFilterDescriptor, ITermVectorFilter> filterSelector) =>
			Assign(filterSelector, (a, v) => a.Filter = v?.Invoke(new TermVectorFilterDescriptor()));

		/// <inheritdoc cref="IMultiTermVectorOperation.Version" />
		public MultiTermVectorOperationDescriptor<T> Version(long? version) => Assign(version, (a, v) => a.Version = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.VersionType" />
		public MultiTermVectorOperationDescriptor<T> VersionType(VersionType? versionType) => Assign(versionType, (a, v) => a.VersionType = v);

		/// <inheritdoc cref="IMultiTermVectorOperation.Routing" />
		public MultiTermVectorOperationDescriptor<T> Routing(Routing routing) => Assign(routing, (a, v) => a.Routing = v);
	}
}
