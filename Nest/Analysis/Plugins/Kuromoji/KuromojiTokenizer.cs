﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A tokenizer of type pattern that can flexibly separate text into terms via a regular expression.
	/// Part of the `analysis-kuromoji` plugin: https://www.elastic.co/guide/en/elasticsearch/plugins/current/analysis-kuromoji.html
	/// </summary>
	public interface IKuromojiTokenizer : ITokenizer
	{
		/// <summary>
		/// Whether punctuation should be discarded from the output. Defaults to true.
		/// </summary>
		[JsonProperty("discard_punctuation")]
		bool? DiscardPunctuation { get; set; }

		/// <summary>
		/// The tokenization mode determines how the tokenizer handles compound and unknown words.
		/// </summary>
		[JsonProperty("mode")]
		KuromojiTokenizationMode? Mode { get; set; }

		/// <summary>
		/// The nbest_cost parameter specifies an additional Viterbi cost. The KuromojiTokenizer will include all tokens in
		/// Viterbi paths that are within the nbest_cost value of the best path.
		/// </summary>
		[JsonProperty("nbest_cost")]
		int? NBestCost { get; set; }

		/// <summary>
		/// The nbest_examples can be used to find a nbest_cost value based on examples. For example,
		///  a value of /箱根山-箱根/成田空港-成田/ indicates that in the texts, 箱根山 (Mt. Hakone) and 成田空港 (Narita Airport)
		///  we’d like a cost that gives is us 箱根 (Hakone) and 成田 (Narita).
		/// </summary>
		[JsonProperty("nbest_examples")]
		string NBestExamples { get; set; }

		/// <summary>
		/// The Kuromoji tokenizer uses the MeCab-IPADIC dictionary by default. A user_dictionary may be
		/// appended to the default dictionary.
		/// </summary>
		[JsonProperty("user_dictionary")]
		string UserDictionary { get; set; }
	}

	/// <inheritdoc />
	public class KuromojiTokenizer : TokenizerBase, IKuromojiTokenizer
	{
		public KuromojiTokenizer() => Type = "kuromoji_tokenizer";

		/// <inheritdoc />
		public bool? DiscardPunctuation { get; set; }

		/// <inheritdoc />
		public KuromojiTokenizationMode? Mode { get; set; }

		/// <inheritdoc />
		public int? NBestCost { get; set; }

		/// <inheritdoc />
		public string NBestExamples { get; set; }

		/// <inheritdoc />
		public string UserDictionary { get; set; }
	}

	/// <inheritdoc />
	public class KuromojiTokenizerDescriptor
		: TokenizerDescriptorBase<KuromojiTokenizerDescriptor, IKuromojiTokenizer>, IKuromojiTokenizer
	{
		protected override string Type => "kuromoji_tokenizer";
		bool? IKuromojiTokenizer.DiscardPunctuation { get; set; }

		KuromojiTokenizationMode? IKuromojiTokenizer.Mode { get; set; }
		int? IKuromojiTokenizer.NBestCost { get; set; }
		string IKuromojiTokenizer.NBestExamples { get; set; }
		string IKuromojiTokenizer.UserDictionary { get; set; }

		/// <inheritdoc />
		public KuromojiTokenizerDescriptor Mode(KuromojiTokenizationMode? mode) => Assign(mode, (a, v) => a.Mode = v);

		/// <inheritdoc />
		public KuromojiTokenizerDescriptor DiscardPunctuation(bool? discard = true) => Assign(discard, (a, v) => a.DiscardPunctuation = v);

		/// <inheritdoc />
		public KuromojiTokenizerDescriptor UserDictionary(string userDictionary) => Assign(userDictionary, (a, v) => a.UserDictionary = v);

		/// <inheritdoc />
		public KuromojiTokenizerDescriptor NBestExamples(string examples) => Assign(examples, (a, v) => a.NBestExamples = v);

		/// <inheritdoc />
		public KuromojiTokenizerDescriptor NBestCost(int? cost) => Assign(cost, (a, v) => a.NBestCost = v);
	}
}
