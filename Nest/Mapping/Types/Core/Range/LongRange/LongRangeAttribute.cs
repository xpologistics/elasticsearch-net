namespace Nest6
{
	public class LongRangeAttribute : RangePropertyAttributeBase, ILongRangeProperty
	{
		public LongRangeAttribute() : base(RangeType.LongRange) { }
	}
}
