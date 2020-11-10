using Newtonsoft.Json;

namespace Nest6
{
	public interface IPointGeoShape : IGeoShape
	{
		[JsonProperty("coordinates")]
		GeoCoordinate Coordinates { get; set; }
	}

	public class PointGeoShape : GeoShapeBase, IPointGeoShape
	{
		public PointGeoShape() : this(null) { }

		public PointGeoShape(GeoCoordinate coordinates)
			: base("point") => Coordinates = coordinates;

		public GeoCoordinate Coordinates { get; set; }
	}
}
