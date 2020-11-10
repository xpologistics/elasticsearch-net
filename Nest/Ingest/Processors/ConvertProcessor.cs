﻿using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	/// <summary>
	/// Converts a field in the currently ingested document to a different type,
	/// such as converting a string to an integer.
	/// If the field value is an array, all members will be converted.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<ConvertProcessor>))]
	public interface IConvertProcessor : IProcessor
	{
		/// <summary>
		/// The field whose value is to be converted
		/// </summary>
		[JsonProperty("field")]
		Field Field { get; set; }

		/// <summary>
		/// The field to assign the converted value to, by default field is updated in-place
		/// </summary>
		[JsonProperty("target_field")]
		Field TargetField { get; set; }

		/// <summary>
		/// The type to convert the existing value to
		/// </summary>
		[JsonProperty("type")]
		ConvertProcessorType? Type { get; set; }

		/// <summary>
		/// If <c>true</c> and <see cref="Field" /> does not exist or is null,
		/// the processor quietly exits without modifying the document. Default is <c>false</c>
		/// </summary>
		[JsonProperty("ignore_missing")]
		bool? IgnoreMissing { get; set; }
	}

	public class ConvertProcessor : ProcessorBase, IConvertProcessor
	{
		/// <inheritdoc />
		public Field Field { get; set; }
		/// <inheritdoc />
		public Field TargetField { get; set; }
		/// <inheritdoc />
		public ConvertProcessorType? Type { get; set; }
		/// <inheritdoc />
		public bool? IgnoreMissing { get; set; }
		/// <inheritdoc />
		protected override string Name => "convert";
	}

	public class ConvertProcessorDescriptor<T> : ProcessorDescriptorBase<ConvertProcessorDescriptor<T>, IConvertProcessor>, IConvertProcessor
		where T : class
	{
		protected override string Name => "convert";
		Field IConvertProcessor.Field { get; set; }
		Field IConvertProcessor.TargetField { get; set; }
		bool? IConvertProcessor.IgnoreMissing { get; set; }
		ConvertProcessorType? IConvertProcessor.Type { get; set; }

		/// <inheritdoc cref="IConvertProcessor.Field" />
		public ConvertProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		/// <inheritdoc cref="IConvertProcessor.Field" />
		public ConvertProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);

		/// <inheritdoc cref="IConvertProcessor.TargetField" />
		public ConvertProcessorDescriptor<T> TargetField(Field field) => Assign(field, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="IConvertProcessor.TargetField" />
		public ConvertProcessorDescriptor<T> TargetField(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="IConvertProcessor.Type" />
		public ConvertProcessorDescriptor<T> Type(ConvertProcessorType? type) => Assign(type, (a, v) => a.Type = v);

		/// <inheritdoc cref="IConvertProcessor.IgnoreMissing" />
		public ConvertProcessorDescriptor<T> IgnoreMissing(bool? ignoreMissing = true) => Assign(ignoreMissing, (a, v) => a.IgnoreMissing = v);
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum ConvertProcessorType
	{
		[EnumMember(Value = "integer")]
		Integer,

		[EnumMember(Value = "long")]
		Long,

		[EnumMember(Value = "float")]
		Float,

		[EnumMember(Value = "double")]
		Double,

		[EnumMember(Value = "string")]
		String,

		[EnumMember(Value = "boolean")]
		Boolean,

		[EnumMember(Value = "auto")]
		Auto
	}
}
