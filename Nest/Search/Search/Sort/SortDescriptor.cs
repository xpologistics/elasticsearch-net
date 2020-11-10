using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Elasticsearch.Net;

namespace Nest6
{
	public class SortDescriptor<T> : DescriptorPromiseBase<SortDescriptor<T>, IList<ISort>>
		where T : class
	{
		public SortDescriptor() : base(new List<ISort>()) { }

		public SortDescriptor<T> Ascending(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Add(new SortField { Field = v, Order = SortOrder.Ascending }));

		public SortDescriptor<T> Descending(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Add(new SortField { Field = v, Order = SortOrder.Descending }));

		public SortDescriptor<T> Ascending(Field field) => Assign(field, (a, v) => a.Add(new SortField { Field = v, Order = SortOrder.Ascending }));

		public SortDescriptor<T> Descending(Field field) => Assign(field, (a, v) => a.Add(new SortField { Field = v, Order = SortOrder.Descending }));

		public SortDescriptor<T> Ascending(SortSpecialField field) =>
			Assign(field.GetStringValue(), (a, v) => a.Add(new SortField { Field = v, Order = SortOrder.Ascending }));

		public SortDescriptor<T> Descending(SortSpecialField field) =>
			Assign(field.GetStringValue(), (a, v) => a.Add(new SortField { Field = v, Order = SortOrder.Descending }));

		public SortDescriptor<T> Field(Func<SortFieldDescriptor<T>, IFieldSort> sortSelector) =>
			AddSort(sortSelector?.Invoke(new SortFieldDescriptor<T>()));

		public SortDescriptor<T> Field(Field field, SortOrder order) => AddSort(new SortField { Field = field, Order = order });

		public SortDescriptor<T> Field(Expression<Func<T, object>> field, SortOrder order) =>
			AddSort(new SortField { Field = field, Order = order });

		public SortDescriptor<T> GeoDistance(Func<SortGeoDistanceDescriptor<T>, IGeoDistanceSort> sortSelector) =>
			AddSort(sortSelector?.Invoke(new SortGeoDistanceDescriptor<T>()));

		public SortDescriptor<T> Script(Func<SortScriptDescriptor<T>, IScriptSort> sortSelector) =>
			AddSort(sortSelector?.Invoke(new SortScriptDescriptor<T>()));

		private SortDescriptor<T> AddSort(ISort sort) => sort == null ? this : Assign(sort, (a, v) => a.Add(v));
	}
}
