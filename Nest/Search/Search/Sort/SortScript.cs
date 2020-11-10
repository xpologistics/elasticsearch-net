﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IScriptSort : ISort
	{
		[JsonProperty("script")]
		IScript Script { get; set; }

		[JsonProperty("type")]
		string Type { get; set; }
	}

	public class ScriptSort : SortBase, IScriptSort
	{
		public string Language { get; set; }
		public IScript Script { get; set; }

		public string Type { get; set; }
		protected override Field SortKey => "_script";
	}

	public class SortScriptDescriptor<T> : SortDescriptorBase<SortScriptDescriptor<T>, IScriptSort, T>, IScriptSort
		where T : class
	{
		protected override Field SortKey => "_script";

		IScript IScriptSort.Script { get; set; }

		string IScriptSort.Type { get; set; }

		public virtual SortScriptDescriptor<T> Type(string type) => Assign(type, (a, v) => a.Type = v);

		public SortScriptDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(scriptSelector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));
	}
}
