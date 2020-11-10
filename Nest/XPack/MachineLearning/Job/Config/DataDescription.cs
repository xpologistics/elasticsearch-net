using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Defines the format of the input data when you send data to the machine learning job.
	/// Note that when configure a datafeed, these properties are automatically set.
	/// </summary>
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<DataDescription>))]
	public interface IDataDescription
	{
		/// <summary>
		/// Only JSON format is supported at this time.
		/// </summary>
		[JsonProperty("format")]
		string Format { get; set; }

		/// <summary>
		/// The name of the field that contains the timestamp. The default value is time.
		/// </summary>
		[JsonProperty("time_field")]
		Field TimeField { get; set; }

		/// <summary>
		/// The time format, which can be epoch, epoch_ms, or a custom pattern.
		/// </summary>
		[JsonProperty("time_format")]
		string TimeFormat { get; set; }
	}

	/// <inheritdoc />
	public class DataDescription : IDataDescription
	{
		/// <inheritdoc />
		public string Format { get; set; }

		/// <inheritdoc />
		public Field TimeField { get; set; }

		/// <inheritdoc />
		public string TimeFormat { get; set; }
	}

	/// <inheritdoc />
	public class DataDescriptionDescriptor<T> : DescriptorBase<DataDescriptionDescriptor<T>, IDataDescription>, IDataDescription
	{
		string IDataDescription.Format { get; set; }
		Field IDataDescription.TimeField { get; set; }
		string IDataDescription.TimeFormat { get; set; }

		/// <inheritdoc />
		public DataDescriptionDescriptor<T> Format(string format) => Assign(format, (a, v) => a.Format = v);

		/// <inheritdoc />
		public DataDescriptionDescriptor<T> TimeField(Field timeField) => Assign(timeField, (a, v) => a.TimeField = v);

		/// <inheritdoc />
		public DataDescriptionDescriptor<T> TimeField(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.TimeField = v);

		/// <inheritdoc />
		public DataDescriptionDescriptor<T> TimeFormat(string timeFormat) => Assign(timeFormat, (a, v) => a.TimeFormat = v);
	}
}
