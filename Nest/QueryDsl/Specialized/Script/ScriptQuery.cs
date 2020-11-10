﻿using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	[ContractJsonConverter(typeof(ScriptQueryConverter))]
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IScriptQuery : IQuery
	{
		[JsonProperty("id")]
		Id Id { get; set; }

		[Obsolete("Use Source. Inline is deprecated and scheduled to be removed in Elasticsearch 7.0")]
		[JsonIgnore]
		string Inline { get; set; }

		[JsonProperty("lang")]
		string Lang { get; set; }

		[JsonProperty("params")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, object>))]
		Dictionary<string, object> Params { get; set; }

		[JsonProperty("source")]
		string Source { get; set; }
	}

	public class ScriptQuery : QueryBase, IScriptQuery
	{
		public Id Id { get; set; }

		[Obsolete("Use Source. Inline is deprecated and scheduled to be removed in Elasticsearch 7.0")]
		public string Inline
		{
			get => Source;
			set => Source = value;
		}

		public string Lang { get; set; }
		public Dictionary<string, object> Params { get; set; }
		public string Source { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Script = this;

		internal static bool IsConditionless(IScriptQuery q) =>
			q.Source.IsNullOrEmpty() && q.Id == null;
	}

	public class ScriptQueryDescriptor<T>
		: QueryDescriptorBase<ScriptQueryDescriptor<T>, IScriptQuery>
			, IScriptQuery where T : class
	{
		protected override bool Conditionless => ScriptQuery.IsConditionless(this);
		Id IScriptQuery.Id { get; set; }

		string IScriptQuery.Inline
		{
			get => Self.Source;
			set => Self.Source = value;
		}

		string IScriptQuery.Lang { get; set; }
		Dictionary<string, object> IScriptQuery.Params { get; set; }
		string IScriptQuery.Source { get; set; }

		/// <summary> Inline script to execute </summary>
		[Obsolete("Use Source(). Inline() is deprecated and scheduled to be removed in Elasticsearch 7.0")]
		public ScriptQueryDescriptor<T> Inline(string script) => Assign(script, (a, v) => a.Inline = v);

		/// <summary> Inline script to execute </summary>
		public ScriptQueryDescriptor<T> Source(string script) => Assign(script, (a, v) => a.Source = v);

		/// <summary> Id of an indexed script to execute </summary>
		public ScriptQueryDescriptor<T> Id(string scriptId) => Assign(scriptId, (a, v) => a.Id = v);

		/// <summary>
		///  Scripts are compiled and cached for faster execution.
		///  If the same script can be used, just with different parameters provided,
		///  it is preferable to use the ability to pass parameters to the script itself.
		/// </summary>
		/// <example>
		/// 	    script: "doc['num1'].value &gt; param1"
		/// 		param: "param1" = 5
		/// </example>
		/// <param name="paramsDictionary">param</param>
		/// <returns>this</returns>
		public ScriptQueryDescriptor<T> Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> paramsDictionary) =>
			Assign(paramsDictionary, (a, v) => a.Params = v?.Invoke(new FluentDictionary<string, object>()));

		/// <summary>
		/// Language of script.
		/// </summary>
		/// <param name="lang">language</param>
		/// <returns>this</returns>
		public ScriptQueryDescriptor<T> Lang(string lang) => Assign(lang, (a, v) => a.Lang = v);

		/// <summary>
		/// Language of script.
		/// </summary>
		/// <param name="lang">language</param>
		/// <returns>this</returns>
		public ScriptQueryDescriptor<T> Lang(ScriptLang lang) => Assign(lang.GetStringValue(), (a, v) => a.Lang = v);
	}
}
