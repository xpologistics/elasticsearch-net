﻿namespace Nest6
{
	public class NestedAttribute : ObjectAttribute, INestedProperty
	{
		public NestedAttribute() : base(FieldType.Nested) { }

		public bool IncludeInParent
		{
			get => Self.IncludeInParent.GetValueOrDefault();
			set => Self.IncludeInParent = value;
		}

		public bool IncludeInRoot
		{
			get => Self.IncludeInRoot.GetValueOrDefault();
			set => Self.IncludeInRoot = value;
		}

		bool? INestedProperty.IncludeInParent { get; set; }
		bool? INestedProperty.IncludeInRoot { get; set; }
		private INestedProperty Self => this;
	}
}
