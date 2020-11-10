﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(VariableFieldNameQueryJsonConverter<GeoPolygonQuery, IGeoPolygonQuery>))]
	public interface IGeoPolygonQuery : IFieldNameQuery
	{
		[VariableField("points")]
		IEnumerable<GeoLocation> Points { get; set; }

		[JsonProperty("validation_method")]
		GeoValidationMethod? ValidationMethod { get; set; }
	}

	public class GeoPolygonQuery : FieldNameQueryBase, IGeoPolygonQuery
	{
		public IEnumerable<GeoLocation> Points { get; set; }

		public GeoValidationMethod? ValidationMethod { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.GeoPolygon = this;

		internal static bool IsConditionless(IGeoPolygonQuery q) => q.Field == null || !q.Points.HasAny();
	}

	public class GeoPolygonQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<GeoPolygonQueryDescriptor<T>, IGeoPolygonQuery, T>
			, IGeoPolygonQuery where T : class
	{
		protected override bool Conditionless => GeoPolygonQuery.IsConditionless(this);
		IEnumerable<GeoLocation> IGeoPolygonQuery.Points { get; set; }
		GeoValidationMethod? IGeoPolygonQuery.ValidationMethod { get; set; }

		public GeoPolygonQueryDescriptor<T> Points(IEnumerable<GeoLocation> points) => Assign(points, (a, v) => a.Points = v);

		public GeoPolygonQueryDescriptor<T> Points(params GeoLocation[] points) => Assign(points, (a, v) => a.Points = v);

		public GeoPolygonQueryDescriptor<T> ValidationMethod(GeoValidationMethod? validation) => Assign(validation, (a, v) => a.ValidationMethod = v);
	}
}
