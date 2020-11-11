﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(FieldNameQueryJsonConverter<MatchPhrasePrefixQuery>))]
	public interface IMatchPhrasePrefixQuery : IFieldNameQuery
	{
		[JsonProperty("analyzer")]
		string Analyzer { get; set; }

		[JsonProperty("max_expansions")]
		int? MaxExpansions { get; set; }

		[JsonProperty("query")]
		string Query { get; set; }

		[JsonProperty("slop")]
		int? Slop { get; set; }

		/// <summary>
		/// If the analyzer used removes all tokens in a query like a stop filter does, the default behavior is
		/// to match no documents at all. In order to change that, <see cref="ZeroTermsQuery" /> can be used,
		/// which accepts <see cref="ZeroTermsQuery.None" /> (default) and <see cref="ZeroTermsQuery.All" />
		/// which corresponds to a match_all query.
		/// </summary>
		[JsonProperty("zero_terms_query")]
		ZeroTermsQuery? ZeroTermsQuery { get; set; }
	}

	public class MatchPhrasePrefixQuery : FieldNameQueryBase, IMatchPhrasePrefixQuery
	{
		public string Analyzer { get; set; }
		public int? MaxExpansions { get; set; }
		public string Query { get; set; }
		public int? Slop { get; set; }

		/// <inheritdoc />
		public ZeroTermsQuery? ZeroTermsQuery { get; set; }

		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.MatchPhrasePrefix = this;

		internal static bool IsConditionless(IMatchPhrasePrefixQuery q) => q.Field.IsConditionless() || q.Query.IsNullOrEmpty();
	}

	public class MatchPhrasePrefixQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<MatchPhrasePrefixQueryDescriptor<T>, IMatchPhrasePrefixQuery, T>, IMatchPhrasePrefixQuery
		where T : class
	{
		protected override bool Conditionless => MatchPhrasePrefixQuery.IsConditionless(this);
		string IMatchPhrasePrefixQuery.Analyzer { get; set; }
		int? IMatchPhrasePrefixQuery.MaxExpansions { get; set; }

		string IMatchPhrasePrefixQuery.Query { get; set; }
		int? IMatchPhrasePrefixQuery.Slop { get; set; }
		ZeroTermsQuery? IMatchPhrasePrefixQuery.ZeroTermsQuery { get; set; }

		public MatchPhrasePrefixQueryDescriptor<T> Query(string query) => Assign(query, (a, v) => a.Query = v);

		public MatchPhrasePrefixQueryDescriptor<T> Analyzer(string analyzer) => Assign(analyzer, (a, v) => a.Analyzer = v);

		public MatchPhrasePrefixQueryDescriptor<T> MaxExpansions(int? maxExpansions) => Assign(maxExpansions, (a, v) => a.MaxExpansions = v);

		public MatchPhrasePrefixQueryDescriptor<T> Slop(int? slop) => Assign(slop, (a, v) => a.Slop = v);

		/// <inheritdoc cref="IMatchQuery.ZeroTermsQuery" />
		public MatchPhrasePrefixQueryDescriptor<T> ZeroTermsQuery(ZeroTermsQuery? zeroTermsQuery) => Assign(zeroTermsQuery, (a, v) => a.ZeroTermsQuery = v);
	}
}