﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization.OptIn)]
	public interface IInlineScriptTransform : IScriptTransform
	{
		[Obsolete("Inline is being deprecated for Source and will be removed in Elasticsearch 7.0")]
		[JsonIgnore]
		string Inline { get; set; }

		[JsonProperty("source")]
		string Source { get; set; }
	}

	public class InlineScriptTransform : ScriptTransformBase, IInlineScriptTransform
	{
		public InlineScriptTransform(string script) => Source = script;

		public string Inline
		{
			get => Source;
			set => Source = value;
		}

		public string Source { get; set; }
	}

	public class InlineScriptTransformDescriptor
		: ScriptTransformDescriptorBase<InlineScriptTransformDescriptor, IInlineScriptTransform>, IInlineScriptTransform
	{
		public InlineScriptTransformDescriptor(string inline) => Self.Source = inline;

		string IInlineScriptTransform.Inline
		{
			get => Self.Source;
			set => Self.Source = value;
		}

		string IInlineScriptTransform.Source { get; set; }
	}
}
