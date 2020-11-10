﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[JsonConverter(typeof(SuggestContextJsonConverter))]
	public interface ISuggestContext
	{
		[JsonProperty("name")]
		string Name { get; set; }

		[JsonProperty("path")]
		Field Path { get; set; }

		[JsonProperty("type")]
		string Type { get; }
	}

	public abstract class SuggestContextBase : ISuggestContext
	{
		public string Name { get; set; }
		public Field Path { get; set; }
		public abstract string Type { get; }
	}

	public abstract class SuggestContextDescriptorBase<TDescriptor, TInterface, T> : DescriptorBase<TDescriptor, TInterface>, ISuggestContext
		where TDescriptor : SuggestContextDescriptorBase<TDescriptor, TInterface, T>, TInterface, ISuggestContext
		where TInterface : class, ISuggestContext
	{
		protected abstract string Type { get; }
		string ISuggestContext.Name { get; set; }
		Field ISuggestContext.Path { get; set; }
		string ISuggestContext.Type => Type;

		public TDescriptor Name(string name) => Assign(name, (a, v) => a.Name = v);

		public TDescriptor Path(Field field) => Assign(field, (a, v) => a.Path = v);

		public TDescriptor Path(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.Path = v);
	}
}
