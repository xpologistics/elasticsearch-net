﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IGeoIndexedShapeQuery : IGeoShapeQuery
	{
		[JsonProperty("indexed_shape")]
		IFieldLookup IndexedShape { get; set; }
	}

	public class GeoIndexedShapeQuery : GeoShapeQueryBase, IGeoIndexedShapeQuery
	{
		public IFieldLookup IndexedShape { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.GeoShape = this;

		internal static bool IsConditionless(IGeoIndexedShapeQuery q) =>
			q.Field.IsConditionless() || q.IndexedShape == null
			|| (q.IndexedShape.Id == null) | (q.IndexedShape.Index == null) || q.IndexedShape.Type == null
			|| q.IndexedShape.Path == null;
	}

	public class GeoIndexedShapeQueryDescriptor<T>
		: GeoShapeQueryDescriptorBase<GeoIndexedShapeQueryDescriptor<T>, IGeoIndexedShapeQuery, T>
			, IGeoIndexedShapeQuery where T : class
	{
		protected override bool Conditionless => GeoIndexedShapeQuery.IsConditionless(this);
		IFieldLookup IGeoIndexedShapeQuery.IndexedShape { get; set; }

		public GeoIndexedShapeQueryDescriptor<T> IndexedShape(Func<FieldLookupDescriptor<T>, IFieldLookup> selector) =>
			Assign(selector, (a, v) => a.IndexedShape = v?.Invoke(new FieldLookupDescriptor<T>()));
	}
}
