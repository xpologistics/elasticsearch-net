﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IEnvelopeGeoShape : IGeoShape
	{
		[JsonProperty("coordinates")]
		IEnumerable<GeoCoordinate> Coordinates { get; set; }
	}

	public class EnvelopeGeoShape : GeoShapeBase, IEnvelopeGeoShape
	{
		public EnvelopeGeoShape() : this(null) { }

		public EnvelopeGeoShape(IEnumerable<GeoCoordinate> coordinates) : base("envelope") =>
			Coordinates = coordinates;

		public IEnumerable<GeoCoordinate> Coordinates { get; set; }
	}
}
