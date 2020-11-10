﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum KeepTypesMode
	{
		[EnumMember(Value = "include")]
		Include,

		[EnumMember(Value = "exclude")]
		Exclude
	}

	/// <summary>
	/// A token filter of type keep that only keeps tokens with text contained in a predefined set of words.
	/// </summary>
	public interface IKeepTypesTokenFilter : ITokenFilter
	{
		/// <summary> Whether to include or exclude the types provided on <see cref="Types" /> </summary>
		[JsonProperty("mode")]
		KeepTypesMode? Mode { get; set; }

		/// <summary> A list of types to keep. </summary>
		[JsonProperty("types")]
		IEnumerable<string> Types { get; set; }
	}

	/// <inheritdoc cref="IKeepTypesTokenFilter" />
	public class KeepTypesTokenFilter : TokenFilterBase
	{
		public KeepTypesTokenFilter() : base("keep_types") { }

		/// <inheritdoc cref="IKeepTypesTokenFilter.Mode" />
		public KeepTypesMode? Mode { get; set; }

		/// <inheritdoc cref="IKeepTypesTokenFilter.Types" />
		public IEnumerable<string> Types { get; set; }
	}

	/// <inheritdoc cref="IKeepTypesTokenFilter" />
	public class KeepTypesTokenFilterDescriptor
		: TokenFilterDescriptorBase<KeepTypesTokenFilterDescriptor, IKeepTypesTokenFilter>, IKeepTypesTokenFilter
	{
		protected override string Type => "keep_types";
		KeepTypesMode? IKeepTypesTokenFilter.Mode { get; set; }

		IEnumerable<string> IKeepTypesTokenFilter.Types { get; set; }

		/// <inheritdoc cref="IKeepTypesTokenFilter.Types" />
		public KeepTypesTokenFilterDescriptor Types(IEnumerable<string> types) => Assign(types, (a, v) => a.Types = v);

		/// <inheritdoc cref="IKeepTypesTokenFilter.Types" />
		public KeepTypesTokenFilterDescriptor Types(params string[] types) => Assign(types, (a, v) => a.Types = v);

		/// <inheritdoc cref="IKeepTypesTokenFilter.Mode" />
		public KeepTypesTokenFilterDescriptor Mode(KeepTypesMode? mode) => Assign(mode, (a, v) => a.Mode = v);
	}
}
