﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// BM25 Similarity. Introduced in Stephen E. Robertson, Steve Walker, Susan Jones, Micheline Hancock-Beaulieu,
	/// and Mike Gatford. Okapi at TREC-3. In Proceedings of the Third Text Retrieval Conference (TREC 1994). Gaithersburg, USA, November 1994.
	/// </summary>
	public interface IBM25Similarity : ISimilarity
	{
		/// <summary>
		/// Controls to what degree document length normalizes tf values.
		/// </summary>
		[JsonProperty("b")]
		double? B { get; set; }

		/// <summary>
		/// Sets whether overlap tokens (Tokens with 0 position increment) are ignored when computing norm.
		/// </summary>
		[JsonProperty("discount_overlaps")]
		bool? DiscountOverlaps { get; set; }

		/// <summary>
		/// Controls non-linear term frequency normalization (saturation).
		/// </summary>
		[JsonProperty("k1")]
		double? K1 { get; set; }
	}

	/// <inheritdoc />
	public class BM25Similarity : IBM25Similarity
	{
		/// <inheritdoc />
		public double? B { get; set; }

		/// <inheritdoc />
		public bool? DiscountOverlaps { get; set; }

		/// <inheritdoc />
		public double? K1 { get; set; }

		public string Type => "BM25";
	}

	/// <inheritdoc />
	public class BM25SimilarityDescriptor
		: DescriptorBase<BM25SimilarityDescriptor, IBM25Similarity>, IBM25Similarity
	{
		double? IBM25Similarity.B { get; set; }
		bool? IBM25Similarity.DiscountOverlaps { get; set; }
		double? IBM25Similarity.K1 { get; set; }
		string ISimilarity.Type => "BM25";

		/// <inheritdoc />
		public BM25SimilarityDescriptor DiscountOverlaps(bool? discount = true) => Assign(discount, (a, v) => a.DiscountOverlaps = v);

		/// <inheritdoc />
		public BM25SimilarityDescriptor K1(double? k1) => Assign(k1, (a, v) => a.K1 = v);

		/// <inheritdoc />
		public BM25SimilarityDescriptor B(double? b) => Assign(b, (a, v) => a.B = v);
	}
}
