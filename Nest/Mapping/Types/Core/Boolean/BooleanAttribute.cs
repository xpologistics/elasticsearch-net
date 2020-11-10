﻿namespace Nest6
{
	public class BooleanAttribute : ElasticsearchDocValuesPropertyAttributeBase, IBooleanProperty
	{
		public BooleanAttribute() : base(FieldType.Boolean) { }

		public double Boost
		{
			get => Self.Boost.GetValueOrDefault();
			set => Self.Boost = value;
		}

		public bool Index
		{
			get => Self.Index.GetValueOrDefault();
			set => Self.Index = value;
		}

		public bool NullValue
		{
			get => Self.NullValue.GetValueOrDefault();
			set => Self.NullValue = value;
		}

		double? IBooleanProperty.Boost { get; set; }
		INumericFielddata IBooleanProperty.Fielddata { get; set; }

		bool? IBooleanProperty.Index { get; set; }
		bool? IBooleanProperty.NullValue { get; set; }
		private IBooleanProperty Self => this;
	}
}
