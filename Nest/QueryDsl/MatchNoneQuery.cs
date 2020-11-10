﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<MatchNoneQuery>))]
	public interface IMatchNoneQuery : IQuery { }

	public class MatchNoneQuery : QueryBase, IMatchNoneQuery
	{
		protected override bool Conditionless => false;

		internal override void InternalWrapInContainer(IQueryContainer container) => container.MatchNone = this;
	}

	public class MatchNoneQueryDescriptor
		: QueryDescriptorBase<MatchNoneQueryDescriptor, IMatchNoneQuery>
			, IMatchNoneQuery
	{
		protected override bool Conditionless => false;
	}
}
