﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Converts a JSON string into a structured JSON object.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<JsonProcessor>))]
	public interface IJsonProcessor : IProcessor
	{
		/// <summary>
		/// Flag that forces the serialized json to be injected into the top level of the document.
		/// <see cref="TargetField" /> must not be set when this option is chosen.
		/// </summary>
		[JsonProperty("add_to_root")]
		bool? AddToRoot { get; set; }

		/// <summary>
		/// Field holding json as a string
		/// </summary>
		[JsonProperty("field")]
		Field Field { get; set; }

		/// <summary>
		/// The field to insert the converted structured object into
		/// </summary>
		[JsonProperty("target_field")]
		Field TargetField { get; set; }
	}

	/// <inheritdoc cref="IJsonProcessor" />
	public class JsonProcessor : ProcessorBase, IJsonProcessor
	{
		/// <inheritdoc />
		public bool? AddToRoot { get; set; }

		/// <inheritdoc />
		public Field Field { get; set; }

		/// <inheritdoc />
		public Field TargetField { get; set; }

		protected override string Name => "json";
	}

	/// <inheritdoc cref="IJsonProcessor" />
	public class JsonProcessorDescriptor<T>
		: ProcessorDescriptorBase<JsonProcessorDescriptor<T>, IJsonProcessor>, IJsonProcessor
		where T : class
	{
		protected override string Name => "json";
		bool? IJsonProcessor.AddToRoot { get; set; }
		Field IJsonProcessor.Field { get; set; }
		Field IJsonProcessor.TargetField { get; set; }

		/// <inheritdoc cref="IJsonProcessor.Field" />
		public JsonProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		/// <inheritdoc cref="IJsonProcessor.Field" />
		public JsonProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);

		/// <inheritdoc cref="IJsonProcessor.TargetField" />
		public JsonProcessorDescriptor<T> TargetField(Field field) => Assign(field, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="IJsonProcessor.TargetField" />
		public JsonProcessorDescriptor<T> TargetField(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="IJsonProcessor.AddToRoot" />
		public JsonProcessorDescriptor<T> AddToRoot(bool? addToRoot = true) => Assign(addToRoot, (a, v) => a.AddToRoot = v);
	}
}
