﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public class DiscoveryNode
	{
		/// <summary>
		/// The node attributes
		/// </summary>
		[JsonProperty("attributes")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, string>))]
		public IReadOnlyDictionary<string, string> Attributes { get; internal set; } = EmptyReadOnly<string, string>.Dictionary;

		/// <summary>
		/// The ephemeral id of the node.
		/// </summary>
		[JsonProperty("ephemeral_id")]
		public string EphemeralId { get; internal set; }

		/// <summary>
		/// The unique identifier of the node.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; internal set; }

		/// <summary>
		/// The node name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; internal set; }

		/// <summary>
		/// The host and port where transport HTTP connections are accepted.
		/// </summary>
		[JsonProperty("transport_address")]
		public string TransportAddress { get; internal set; }
	}
}
