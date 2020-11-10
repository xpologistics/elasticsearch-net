﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IGeoShapeMultiLineStringQuery : IGeoShapeQuery
	{
		[JsonProperty("shape")]
		IMultiLineStringGeoShape Shape { get; set; }
	}

	public class GeoShapeMultiLineStringQuery : GeoShapeQueryBase, IGeoShapeMultiLineStringQuery
	{
		private IMultiLineStringGeoShape _shape;

		public IMultiLineStringGeoShape Shape
		{
			get => _shape;
			set
			{
#pragma warning disable 618
				if (value?.IgnoreUnmapped != null)
				{
					IgnoreUnmapped = value.IgnoreUnmapped;
					value.IgnoreUnmapped = null;
				}
#pragma warning restore 618
				_shape = value;
			}
		}

		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.GeoShape = this;

		internal static bool IsConditionless(IGeoShapeMultiLineStringQuery q) =>
			q.Field.IsConditionless() || q.Shape == null || !q.Shape.Coordinates.HasAny();
	}

	public class GeoShapeMultiLineStringQueryDescriptor<T>
		: GeoShapeQueryDescriptorBase<GeoShapeMultiLineStringQueryDescriptor<T>, IGeoShapeMultiLineStringQuery, T>
			, IGeoShapeMultiLineStringQuery where T : class
	{
		protected override bool Conditionless => GeoShapeMultiLineStringQuery.IsConditionless(this);
		IMultiLineStringGeoShape IGeoShapeMultiLineStringQuery.Shape { get; set; }

		public GeoShapeMultiLineStringQueryDescriptor<T> Coordinates(IEnumerable<IEnumerable<GeoCoordinate>> coordinates, bool? ignoreUnmapped = null) =>
			Assign(coordinates,(a, v) =>
			{
				a.Shape = a.Shape ?? new MultiLineStringGeoShape();
				a.Shape.Coordinates = v;
			})
			.Assign(ignoreUnmapped, (a, v) => a.IgnoreUnmapped = v);
	}
}
