﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<AppendProcessor>))]
	public interface IAppendProcessor : IProcessor
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("value")]
		IEnumerable<object> Value { get; set; }
	}

	public class AppendProcessor : ProcessorBase, IAppendProcessor
	{
		public Field Field { get; set; }
		public IEnumerable<object> Value { get; set; }
		protected override string Name => "append";
	}

	public class AppendProcessorDescriptor<T> : ProcessorDescriptorBase<AppendProcessorDescriptor<T>, IAppendProcessor>, IAppendProcessor
		where T : class
	{
		protected override string Name => "append";
		Field IAppendProcessor.Field { get; set; }
		IEnumerable<object> IAppendProcessor.Value { get; set; }

		public AppendProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public AppendProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);

		public AppendProcessorDescriptor<T> Value<TValue>(IEnumerable<TValue> values) => Assign(values, (a, v) => a.Value = v?.Cast<object>());

		public AppendProcessorDescriptor<T> Value<TValue>(params TValue[] values) => Assign(values, (a, v) =>
		{
			if (v?.Length == 1 && typeof(IEnumerable).IsAssignableFrom(typeof(TValue)) && typeof(TValue) != typeof(string))
				a.Value = (v.First() as IEnumerable)?.Cast<object>();
			else a.Value = v?.Cast<object>();
		});
	}
}
