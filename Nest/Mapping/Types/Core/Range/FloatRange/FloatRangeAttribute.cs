namespace Nest6
{
	public class IntegerRangeAttribute : RangePropertyAttributeBase, IIntegerRangeProperty
	{
		public IntegerRangeAttribute() : base(RangeType.IntegerRange) { }
	}
}
