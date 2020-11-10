﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// A similarity that allows a script to be used in order to specify how scores should be computed.
	/// </summary>
	/// <remarks>
	/// Valid in Elasticsearch 6.1.0+
	/// </remarks>
	public interface IScriptedSimilarity : ISimilarity
	{
		/// <summary>
		/// Script to calculate similarity
		/// </summary>
		[JsonProperty("script")]
		IScript Script { get; set; }
	}

	/// <inheritdoc />
	public class ScriptedSimilarity : IScriptedSimilarity
	{
		/// <inheritdoc />
		public IScript Script { get; set; }

		public string Type => "scripted";
	}

	/// <inheritdoc cref="IScriptedSimilarity" />
	public class ScriptedSimilarityDescriptor
		: DescriptorBase<ScriptedSimilarityDescriptor, IScriptedSimilarity>, IScriptedSimilarity
	{
		IScript IScriptedSimilarity.Script { get; set; }
		string ISimilarity.Type => "scripted";

		/// <inheritdoc cref="IScriptedSimilarity.Script" />
		public ScriptedSimilarityDescriptor Script(Func<ScriptDescriptor, IScript> selector) =>
			Assign(selector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));
	}
}
