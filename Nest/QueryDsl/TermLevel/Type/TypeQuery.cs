﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<TypeQueryDescriptor>))]
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface ITypeQuery : IQuery
	{
		[JsonProperty("value")]
		TypeName Value { get; set; }
	}

	public class TypeQuery : QueryBase, ITypeQuery
	{
		public TypeName Value { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Type = this;

		internal static bool IsConditionless(ITypeQuery q) => q.Value.IsConditionless();
	}

	public class TypeQueryDescriptor
		: QueryDescriptorBase<TypeQueryDescriptor, ITypeQuery>
			, ITypeQuery
	{
		protected override bool Conditionless => TypeQuery.IsConditionless(this);

		[JsonProperty("value")]
		TypeName ITypeQuery.Value { get; set; }

		public TypeQueryDescriptor Value<T>() => Assign(typeof(T), (a, v) => a.Value = v);

		public TypeQueryDescriptor Value(TypeName type) => Assign(type, (a, v) => a.Value = v);
	}
}
