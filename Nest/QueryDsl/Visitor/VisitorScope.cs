﻿namespace Nest6
{
	public enum VisitorScope
	{
		Unknown,
		Query,
		Filter,
		Must,
		MustNot,
		Should,
		PositiveQuery,
		NegativeQuery,
		Span,
	}
}
