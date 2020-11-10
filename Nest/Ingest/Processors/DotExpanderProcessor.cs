﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Expands a field with dots into an object field.
	/// This processor allows fields with dots in the name to be accessible by other processors in the pipeline.
	/// Otherwise these fields can’t be accessed by any processor.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<DotExpanderProcessor>))]
	public interface IDotExpanderProcessor : IProcessor
	{
		/// <summary>
		/// The field to expand into an object field
		/// </summary>
		[JsonProperty("field")]
		Field Field { get; set; }

		/// <summary>
		/// The field that contains the field to expand.
		/// Only required if the field to expand is part another object field,
		/// because the field option can only understand leaf fields.
		/// </summary>
		[JsonProperty("path")]
		string Path { get; set; }
	}

	/// <inheritdoc cref="IDotExpanderProcessor" />
	public class DotExpanderProcessor : ProcessorBase, IDotExpanderProcessor
	{
		/// <inheritdoc />
		[JsonProperty("field")]
		public Field Field { get; set; }

		/// <inheritdoc />
		[JsonProperty("path")]
		public string Path { get; set; }

		protected override string Name => "dot_expander";
	}

	/// <inheritdoc cref="IDotExpanderProcessor" />
	public class DotExpanderProcessorDescriptor<T>
		: ProcessorDescriptorBase<DotExpanderProcessorDescriptor<T>, IDotExpanderProcessor>, IDotExpanderProcessor
		where T : class
	{
		protected override string Name => "dot_expander";

		Field IDotExpanderProcessor.Field { get; set; }
		string IDotExpanderProcessor.Path { get; set; }

		/// <inheritdoc cref="IDotExpanderProcessor.Field" />
		public DotExpanderProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		/// <inheritdoc cref="IDotExpanderProcessor.Field" />
		public DotExpanderProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);

		/// <inheritdoc cref="IDotExpanderProcessor.Path" />
		public DotExpanderProcessorDescriptor<T> Path(string path) => Assign(path, (a, v) => a.Path = v);
	}
}
