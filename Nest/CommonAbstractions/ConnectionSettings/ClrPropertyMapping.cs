﻿using System;
using System.Linq.Expressions;

namespace Nest6
{
	public abstract class ClrPropertyMappingBase<TDocument> : IClrPropertyMapping<TDocument>
		where TDocument : class
	{
		protected ClrPropertyMappingBase(Expression<Func<TDocument, object>> property) => Self.Property = property;

		protected IClrPropertyMapping<TDocument> Self => this;
		bool IClrPropertyMapping<TDocument>.Ignore { get; set; }
		string IClrPropertyMapping<TDocument>.NewName { get; set; }
		Expression<Func<TDocument, object>> IClrPropertyMapping<TDocument>.Property { get; set; }

		IPropertyMapping IClrPropertyMapping<TDocument>.ToPropertyMapping() => Self.Ignore
			? PropertyMapping.Ignored
			: new PropertyMapping { Name = Self.NewName };
	}

	public interface IClrPropertyMapping<TDocument> where TDocument : class
	{
		bool Ignore { get; set; }
		string NewName { get; set; }
		Expression<Func<TDocument, object>> Property { get; set; }

		IPropertyMapping ToPropertyMapping();
	}

	public class IgnoreClrPropertyMapping<TDocument> : ClrPropertyMappingBase<TDocument> where TDocument : class
	{
		public IgnoreClrPropertyMapping(Expression<Func<TDocument, object>> property) : base(property) => Self.Ignore = true;
	}

	public class RenameClrPropertyMapping<TDocument> : ClrPropertyMappingBase<TDocument> where TDocument : class
	{
		public RenameClrPropertyMapping(Expression<Func<TDocument, object>> property, string newName) : base(property)
		{
			newName.ThrowIfNull(nameof(newName));
			Self.NewName = newName;
		}
	}
}
