﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Converts a human readable byte value (e.g. 1kb) to its value in bytes (e.g. 1024).
	/// Supported human readable units are "b", "kb", "mb", "gb", "tb", "pb" case insensitive.
	/// An error will occur if the field is not a supported format or resultant value exceeds 2^63.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<BytesProcessor>))]
	public interface IBytesProcessor : IProcessor
	{
		/// <summary> The field to convert bytes from </summary>
		[JsonProperty("field")]
		Field Field { get; set; }

		/// <summary>
		/// If <c>true</c> and <see cref="Field" /> does not exist or is null,
		/// the processor quietly exits without modifying the document. Default is <c>false</c>
		/// </summary>
		[JsonProperty("ignore_missing")]
		bool? IgnoreMissing { get; set; }

		/// <summary> The field to assign the converted value to, by default <see cref="Field" /> is updated in-place </summary>
		[JsonProperty("target_field")]
		Field TargetField { get; set; }
	}

	/// <inheritdoc cref="IBytesProcessor" />
	public class BytesProcessor : ProcessorBase, IBytesProcessor
	{
		/// <inheritdoc />
		[JsonProperty("field")]
		public Field Field { get; set; }

		/// <inheritdoc />
		[JsonProperty("ignore_missing")]
		public bool? IgnoreMissing { get; set; }

		/// <inheritdoc />
		[JsonProperty("target_field")]
		public Field TargetField { get; set; }

		protected override string Name => "bytes";
	}

	/// <inheritdoc cref="IBytesProcessor" />
	public class BytesProcessorDescriptor<T>
		: ProcessorDescriptorBase<BytesProcessorDescriptor<T>, IBytesProcessor>, IBytesProcessor
		where T : class
	{
		protected override string Name => "bytes";

		Field IBytesProcessor.Field { get; set; }
		bool? IBytesProcessor.IgnoreMissing { get; set; }
		Field IBytesProcessor.TargetField { get; set; }

		/// <inheritdoc cref="IBytesProcessor.Field" />
		public BytesProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		/// <inheritdoc cref="IBytesProcessor.Field" />
		public BytesProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.Field = v);

		/// <inheritdoc cref="IBytesProcessor.TargetField" />
		public BytesProcessorDescriptor<T> TargetField(Field field) => Assign(field, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="IBytesProcessor.TargetField" />
		public BytesProcessorDescriptor<T> TargetField(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="IBytesProcessor.IgnoreMissing" />
		public BytesProcessorDescriptor<T> IgnoreMissing(bool? ignoreMissing = true) => Assign(ignoreMissing, (a, v) => a.IgnoreMissing = v);
	}
}
