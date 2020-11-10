﻿using Newtonsoft.Json;

namespace Nest6
{
	public interface ICircleGeoShape : IGeoShape
	{
		[JsonProperty("coordinates")]
		GeoCoordinate Coordinates { get; set; }

		[JsonProperty("radius")]
		string Radius { get; set; }
	}

	public class CircleGeoShape : GeoShapeBase, ICircleGeoShape
	{
		public CircleGeoShape() : this(null) { }

		public CircleGeoShape(GeoCoordinate location) : base("circle") => Coordinates = location;

		public GeoCoordinate Coordinates { get; set; }

		public string Radius { get; set; }
	}
}
