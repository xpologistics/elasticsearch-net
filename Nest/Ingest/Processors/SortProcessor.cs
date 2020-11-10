﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Sorts the elements of an array ascending or descending. Homogeneous arrays of numbers
	/// will be sorted numerically, while arrays of strings or heterogeneous arrays
	///  of strings and numbers will be sorted lexicographically.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<SortProcessor>))]
	public interface ISortProcessor : IProcessor
	{
		/// <summary>
		/// The field to be sorted
		/// </summary>
		[JsonProperty("field")]
		Field Field { get; set; }

		/// <summary>
		/// The sort order to use. Default is ascending.
		/// </summary>
		[JsonProperty("order")]
		SortOrder? Order { get; set; }

		/// <summary>
		/// The field to assign the sorted value to, by default field is updated in-place
		/// </summary>
		[JsonProperty("target_field")]
		Field TargetField { get; set; }
	}

	/// <inheritdoc cref="ISortProcessor" />
	public class SortProcessor : ProcessorBase, ISortProcessor
	{
		/// <inheritdoc />
		public Field Field { get; set; }

		/// <inheritdoc />
		public SortOrder? Order { get; set; }

		/// <inheritdoc />
		public Field TargetField { get; set; }

		protected override string Name => "sort";
	}

	/// <inheritdoc cref="ISortProcessor" />
	public class SortProcessorDescriptor<T>
		: ProcessorDescriptorBase<SortProcessorDescriptor<T>, ISortProcessor>, ISortProcessor
		where T : class
	{
		protected override string Name => "sort";

		Field ISortProcessor.Field { get; set; }
		SortOrder? ISortProcessor.Order { get; set; }
		Field ISortProcessor.TargetField { get; set; }

		/// <inheritdoc cref="ISortProcessor.Field" />
		public SortProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		/// <inheritdoc cref="ISortProcessor.Field" />
		public SortProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);

		/// <inheritdoc cref="ISortProcessor.TargetField" />
		public SortProcessorDescriptor<T> TargetField(Field field) => Assign(field, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="ISortProcessor.TargetField" />
		public SortProcessorDescriptor<T> TargetField(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.TargetField = v);

		/// <inheritdoc cref="ISortProcessor.Order" />
		public SortProcessorDescriptor<T> Order(SortOrder? order = SortOrder.Ascending) =>
			Assign(order, (a, v) => a.Order = v);
	}
}
