﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// The parent_id query can be used to find child documents which belong to a particular parent.
	/// </summary>
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<ParentIdQuery>))]
	public interface IParentIdQuery : IQuery
	{
		/// <summary>
		/// The id of the parent document to get children for.
		/// </summary>
		[JsonProperty("id")]
		Id Id { get; set; }

		/// <summary>
		/// When set to true this will ignore an unmapped type and will not match any documents for
		/// this query. This can be useful when querying multiple indexes which might have different mappings.
		/// </summary>
		[JsonProperty("ignore_unmapped")]
		bool? IgnoreUnmapped { get; set; }

		/// <summary>
		/// The child type. This must be a type with _parent field.
		/// </summary>
		[JsonProperty("type")]
		RelationName Type { get; set; }
	}

	public class ParentIdQuery : QueryBase, IParentIdQuery
	{
		public Id Id { get; set; }

		public bool? IgnoreUnmapped { get; set; }

		public RelationName Type { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.ParentId = this;

		internal static bool IsConditionless(IParentIdQuery q) => q.Type.IsConditionless() || q.Id.IsConditionless();
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class ParentIdQueryDescriptor<T>
		: QueryDescriptorBase<ParentIdQueryDescriptor<T>, IParentIdQuery>
			, IParentIdQuery where T : class
	{
		protected override bool Conditionless => ParentIdQuery.IsConditionless(this);
		Id IParentIdQuery.Id { get; set; }
		bool? IParentIdQuery.IgnoreUnmapped { get; set; }

		RelationName IParentIdQuery.Type { get; set; }

		public ParentIdQueryDescriptor<T> Id(Id id) => Assign(id, (a, v) => a.Id = v);

		public ParentIdQueryDescriptor<T> Type(RelationName type) => Assign(type, (a, v) => a.Type = v);

		public ParentIdQueryDescriptor<T> Type<TChild>() => Assign(typeof(TChild), (a, v) => a.Type = v);

		public ParentIdQueryDescriptor<T> IgnoreUnmapped(bool? ignoreUnmapped = true) => Assign(ignoreUnmapped, (a, v) => a.IgnoreUnmapped = v);
	}
}
