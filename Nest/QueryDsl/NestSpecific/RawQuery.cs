﻿namespace Nest6
{
	public interface IRawQuery : IQuery
	{
		string Raw { get; set; }
	}

	public class RawQuery : QueryBase, IRawQuery
	{
		public RawQuery() { }

		public RawQuery(string rawQuery) => Raw = rawQuery;

		public string Raw { get; set; }

		protected override bool Conditionless => Raw.IsNullOrEmpty();

		internal override void InternalWrapInContainer(IQueryContainer container) => container.RawQuery = this;
	}

	public class RawQueryDescriptor : QueryDescriptorBase<RawQueryDescriptor, IRawQuery>, IRawQuery
	{
		public RawQueryDescriptor() { }

		public RawQueryDescriptor(string rawQuery) => Self.Raw = rawQuery;

		protected override bool Conditionless => Self.Raw.IsNullOrEmpty();
		string IRawQuery.Raw { get; set; }

		public RawQueryDescriptor Raw(string rawQuery) =>
			Assign(rawQuery, (a, v) => a.Raw = v);
	}
}
