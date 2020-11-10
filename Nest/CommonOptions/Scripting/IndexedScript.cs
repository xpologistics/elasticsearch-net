﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IIndexedScript : IScript
	{
		[JsonProperty("id")]
		string Id { get; set; }
	}

	public class IndexedScript : ScriptBase, IIndexedScript
	{
		public IndexedScript(string id) => Id = id;

		public string Id { get; set; }
	}

	public class IndexedScriptDescriptor
		: ScriptDescriptorBase<IndexedScriptDescriptor, IIndexedScript>, IIndexedScript
	{
		public IndexedScriptDescriptor() { }

		public IndexedScriptDescriptor(string id) => Self.Id = id;

		string IIndexedScript.Id { get; set; }

		public IndexedScriptDescriptor Id(string id) => Assign(id, (a, v) => a.Id = v);
	}
}
