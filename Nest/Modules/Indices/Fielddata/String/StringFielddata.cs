﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<StringFielddata>))]
	public interface IStringFielddata : IFielddata
	{
		[JsonProperty("format")]
		StringFielddataFormat? Format { get; set; }
	}

	public class StringFielddata : FielddataBase, IStringFielddata
	{
		public StringFielddataFormat? Format { get; set; }
	}

	public class StringFielddataDescriptor
		: FielddataDescriptorBase<StringFielddataDescriptor, IStringFielddata>, IStringFielddata
	{
		StringFielddataFormat? IStringFielddata.Format { get; set; }

		public StringFielddataDescriptor Format(StringFielddataFormat? format) => Assign(format, (a, v) => a.Format = v);
	}
}
