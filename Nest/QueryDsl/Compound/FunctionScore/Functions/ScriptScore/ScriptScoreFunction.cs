﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IScriptScoreFunction : IScoreFunction
	{
		[JsonProperty("script")]
		IScriptQuery Script { get; set; }
	}

	public class ScriptScoreFunction : FunctionScoreFunctionBase, IScriptScoreFunction
	{
		public IScriptQuery Script { get; set; }
	}

	public class ScriptScoreFunctionDescriptor<T>
		: FunctionScoreFunctionDescriptorBase<ScriptScoreFunctionDescriptor<T>, IScriptScoreFunction, T>, IScriptScoreFunction
		where T : class
	{
		IScriptQuery IScriptScoreFunction.Script { get; set; }

		public ScriptScoreFunctionDescriptor<T> Script(Func<ScriptQueryDescriptor<T>, IScriptQuery> selector) =>
			Assign(selector, (a, v) => a.Script = v?.Invoke(new ScriptQueryDescriptor<T>()));
	}
}
