﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A query to run for a phrase suggester collate
	/// </summary>
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<PhraseSuggestCollateQuery>))]
	public interface IPhraseSuggestCollateQuery
	{
		/// <summary>
		/// The id for a stored script to execute
		/// </summary>
		[JsonProperty("id")]
		Id Id { get; set; }

		/// <summary>
		/// The source script to be executed
		/// </summary>
		[JsonProperty("source")]
		string Source { get; set; }
	}

	/// <inheritdoc />
	public class PhraseSuggestCollateQuery : IPhraseSuggestCollateQuery
	{
		/// <inheritdoc />
		public Id Id { get; set; }

		/// <inheritdoc />
		public string Source { get; set; }
	}

	/// <inheritdoc />
	public class PhraseSuggestCollateQueryDescriptor
		: DescriptorBase<PhraseSuggestCollateQueryDescriptor, IPhraseSuggestCollateQuery>, IPhraseSuggestCollateQuery
	{
		Id IPhraseSuggestCollateQuery.Id { get; set; }
		string IPhraseSuggestCollateQuery.Source { get; set; }

		/// <inheritdoc />
		public PhraseSuggestCollateQueryDescriptor Source(string source) => Assign(source, (a, v) => a.Source = v);

		/// <inheritdoc />
		public PhraseSuggestCollateQueryDescriptor Id(Id id) => Assign(id, (a, v) => a.Id = v);
	}
}
