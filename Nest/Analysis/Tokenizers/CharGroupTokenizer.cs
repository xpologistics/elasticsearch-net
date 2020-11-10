﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A tokenizer that breaks text into terms whenever it encounters a character which is in a defined set. It is mostly useful
	/// for cases where a simple custom tokenization is desired, and the overhead of use of <see cref="PatternTokenizer" /> is not acceptable.
	/// </summary>
	public interface ICharGroupTokenizer : ITokenizer
	{
		/// <summary>
		/// A list containing a list of characters to tokenize the string on. Whenever a character from this list is encountered, a
		/// new token is started. This accepts either single characters like eg. -, or character groups: whitespace, letter, digit,
		/// punctuation, symbol.
		/// </summary>
		[JsonProperty("tokenize_on_chars")]
		IEnumerable<string> TokenizeOnCharacters { get; set; }
	}

	/// <inheritdoc cref="ICharGroupTokenizer" />
	public class CharGroupTokenizer : TokenizerBase, ICharGroupTokenizer
	{
		internal const string TokenizerType = "char_group";

		public CharGroupTokenizer() => Type = TokenizerType;

		/// <inheritdoc cref="ICharGroupTokenizer.TokenizeOnCharacters" />
		public IEnumerable<string> TokenizeOnCharacters { get; set; }
	}

	/// <inheritdoc cref="ICharGroupTokenizer" />
	public class CharGroupTokenizerDescriptor
		: TokenizerDescriptorBase<CharGroupTokenizerDescriptor, ICharGroupTokenizer>, ICharGroupTokenizer
	{
		protected override string Type => CharGroupTokenizer.TokenizerType;

		IEnumerable<string> ICharGroupTokenizer.TokenizeOnCharacters { get; set; }

		/// <inheritdoc cref="ICharGroupTokenizer.TokenizeOnCharacters" />
		public CharGroupTokenizerDescriptor TokenizeOnCharacters(params string[] characters) =>
			Assign(characters, (a, v) => a.TokenizeOnCharacters = v);

		/// <inheritdoc cref="ICharGroupTokenizer.TokenizeOnCharacters" />
		public CharGroupTokenizerDescriptor TokenizeOnCharacters(IEnumerable<string> characters) =>
			Assign(characters, (a, v) => a.TokenizeOnCharacters = v);
	}
}
