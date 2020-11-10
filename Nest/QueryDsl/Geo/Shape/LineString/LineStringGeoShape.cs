﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface ILineStringGeoShape : IGeoShape
	{
		[JsonProperty("coordinates")]
		IEnumerable<GeoCoordinate> Coordinates { get; set; }
	}

	public class LineStringGeoShape : GeoShapeBase, ILineStringGeoShape
	{
		public LineStringGeoShape() : this(null) { }

		public LineStringGeoShape(IEnumerable<GeoCoordinate> coordinates)
			: base("linestring") => Coordinates = coordinates;

		public IEnumerable<GeoCoordinate> Coordinates { get; set; }
	}
}
