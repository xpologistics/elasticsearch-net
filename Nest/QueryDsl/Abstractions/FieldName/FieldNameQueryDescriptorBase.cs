﻿using System;
using System.Linq.Expressions;

namespace Nest6
{
	public abstract class FieldNameQueryDescriptorBase<TDescriptor, TInterface, T>
		: QueryDescriptorBase<TDescriptor, TInterface>, IFieldNameQuery
		where TDescriptor : FieldNameQueryDescriptorBase<TDescriptor, TInterface, T>, TInterface
		where TInterface : class, IFieldNameQuery
		where T : class
	{
		Field IFieldNameQuery.Field { get; set; }

		bool IQuery.IsStrict { get; set; }

		bool IQuery.IsVerbatim { get; set; }

		public TDescriptor Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public TDescriptor Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);
	}
}
