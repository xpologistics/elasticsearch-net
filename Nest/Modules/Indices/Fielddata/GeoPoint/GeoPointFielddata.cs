﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization.OptIn)]
	public interface IGeoPointFielddata : IFielddata
	{
		[JsonProperty("format")]
		GeoPointFielddataFormat? Format { get; set; }

		[JsonProperty("precision")]
		Distance Precision { get; set; }
	}

	public class GeoPointFielddata : FielddataBase, IGeoPointFielddata
	{
		public GeoPointFielddataFormat? Format { get; set; }
		public Distance Precision { get; set; }
	}

	public class GeoPointFielddataDescriptor
		: FielddataDescriptorBase<GeoPointFielddataDescriptor, IGeoPointFielddata>, IGeoPointFielddata
	{
		GeoPointFielddataFormat? IGeoPointFielddata.Format { get; set; }
		Distance IGeoPointFielddata.Precision { get; set; }

		public GeoPointFielddataDescriptor Format(GeoPointFielddataFormat? format) => Assign(format, (a, v) => a.Format = v);

		public GeoPointFielddataDescriptor Precision(Distance distance) => Assign(distance, (a, v) => a.Precision = v);
	}
}
