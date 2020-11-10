﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Converts a string to its lowercase equivalent.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<LowercaseProcessor>))]
	public interface ILowercaseProcessor : IProcessor
	{
		/// <summary>
		/// 	The field to make lowercase
		/// </summary>
		[JsonProperty("field")]
		Field Field { get; set; }

		/// <summary>
		/// If <c>true</c> and <see cref="Field" /> does not exist or is null,
		/// the processor quietly exits without modifying the document
		/// </summary>
		[JsonProperty("ignore_missing")]
		bool? IgnoreMissing { get; set; }

		/// <summary>
		/// The field to assign the converted value to, by default field is updated in-place
		/// </summary>
		[JsonProperty("target_field")]
		Field TargetField { get; set; }
	}

	/// <inheritdoc cref="ILowercaseProcessor" />
	public class LowercaseProcessor : ProcessorBase, ILowercaseProcessor
	{
		/// <inheritdoc />
		public Field Field { get; set; }
		/// <inheritdoc />
		public bool? IgnoreMissing { get; set; }
		/// <inheritdoc />
		public Field TargetField { get; set; }
		protected override string Name => "lowercase";
	}

	/// <inheritdoc cref="ILowercaseProcessor" />
	public class LowercaseProcessorDescriptor<T>
		: ProcessorDescriptorBase<LowercaseProcessorDescriptor<T>, ILowercaseProcessor>, ILowercaseProcessor
		where T : class
	{
		protected override string Name => "lowercase";

		Field ILowercaseProcessor.Field { get; set; }
		bool? ILowercaseProcessor.IgnoreMissing { get; set; }
		Field ILowercaseProcessor.TargetField { get; set; }

		/// <inheritdoc cref="ILowercaseProcessor.Field" />
		public LowercaseProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		/// <inheritdoc cref="ILowercaseProcessor.Field" />
		public LowercaseProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);

		/// <inheritdoc cref="ILowercaseProcessor.TargetField" />
		public LowercaseProcessorDescriptor<T> TargetField(Field field) => Assign(field, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="ILowercaseProcessor.TargetField" />
		public LowercaseProcessorDescriptor<T> TargetField(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="ILowercaseProcessor.IgnoreMissing" />
		public LowercaseProcessorDescriptor<T> IgnoreMissing(bool? ignoreMissing = true) =>
			Assign(ignoreMissing, (a, v) => a.IgnoreMissing = v);
	}
}
