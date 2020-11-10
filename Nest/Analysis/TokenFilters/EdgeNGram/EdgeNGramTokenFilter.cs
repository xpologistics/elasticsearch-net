﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A token filter of type edgeNGram.
	/// </summary>
	public interface IEdgeNGramTokenFilter : ITokenFilter
	{
		/// <summary>
		/// Defaults to 2.
		/// </summary>
		[JsonProperty("max_gram")]
		int? MaxGram { get; set; }

		/// <summary>
		/// Defaults to 1.
		/// </summary>
		[JsonProperty("min_gram")]
		int? MinGram { get; set; }

		/// <summary>
		/// Either front or back. Defaults to front.
		/// </summary>
		[JsonProperty("side")]
		EdgeNGramSide? Side { get; set; }
	}

	/// <inheritdoc />
	public class EdgeNGramTokenFilter : TokenFilterBase, IEdgeNGramTokenFilter
	{
		public EdgeNGramTokenFilter() : base("edge_ngram") { }

		/// <inheritdoc />
		public int? MaxGram { get; set; }

		/// <inheritdoc />
		public int? MinGram { get; set; }

		/// <inheritdoc />
		public EdgeNGramSide? Side { get; set; }
	}

	/// <inheritdoc />
	public class EdgeNGramTokenFilterDescriptor
		: TokenFilterDescriptorBase<EdgeNGramTokenFilterDescriptor, IEdgeNGramTokenFilter>, IEdgeNGramTokenFilter
	{
		protected override string Type => "edge_ngram";
		int? IEdgeNGramTokenFilter.MaxGram { get; set; }

		int? IEdgeNGramTokenFilter.MinGram { get; set; }
		EdgeNGramSide? IEdgeNGramTokenFilter.Side { get; set; }

		/// <inheritdoc />
		public EdgeNGramTokenFilterDescriptor MinGram(int? minGram) => Assign(minGram, (a, v) => a.MinGram = v);

		/// <inheritdoc />
		public EdgeNGramTokenFilterDescriptor MaxGram(int? maxGram) => Assign(maxGram, (a, v) => a.MaxGram = v);

		/// <inheritdoc />
		public EdgeNGramTokenFilterDescriptor Side(EdgeNGramSide? side) => Assign(side, (a, v) => a.Side = v);
	}
}
