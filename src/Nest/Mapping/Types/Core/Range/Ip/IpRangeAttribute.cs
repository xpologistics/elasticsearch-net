namespace Nest6
{
	public class IpRangeAttribute : RangePropertyAttributeBase, IIpRangeProperty
	{
		public IpRangeAttribute() : base(RangeType.IpRange) { }
	}
}
