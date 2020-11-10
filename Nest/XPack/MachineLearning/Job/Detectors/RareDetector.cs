using System;
using System.Linq.Expressions;

namespace Nest6
{
	public enum RareFunction
	{
		Rare,
		FreqRare
	}

	public static class RareFunctionsExtensions
	{
		public static string GetStringValue(this RareFunction rareFunction)
		{
			switch (rareFunction)
			{
				case RareFunction.Rare:
					return "rare";
				case RareFunction.FreqRare:
					return "freq_rare";
				default:
					throw new ArgumentOutOfRangeException(nameof(rareFunction), rareFunction, null);
			}
		}
	}

	public interface IRareDetector
		: IDetector, IByFieldNameDetector, IOverFieldNameDetector,
			IPartitionFieldNameDetector { }

	public abstract class RareDetectorBase : DetectorBase, IRareDetector
	{
		protected RareDetectorBase(RareFunction function) : base(function.GetStringValue()) { }

		public Field ByFieldName { get; set; }
		public Field OverFieldName { get; set; }
		public Field PartitionFieldName { get; set; }
	}

	public class RareDetectorDescriptor<T> : DetectorDescriptorBase<RareDetectorDescriptor<T>, IRareDetector>, IRareDetector where T : class
	{
		public RareDetectorDescriptor(RareFunction function) : base(function.GetStringValue()) { }

		Field IByFieldNameDetector.ByFieldName { get; set; }
		Field IOverFieldNameDetector.OverFieldName { get; set; }
		Field IPartitionFieldNameDetector.PartitionFieldName { get; set; }

		public RareDetectorDescriptor<T> ByFieldName(Field byFieldName) => Assign(byFieldName, (a, v) => a.ByFieldName = v);

		public RareDetectorDescriptor<T> ByFieldName(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.ByFieldName = v);

		public RareDetectorDescriptor<T> OverFieldName(Field overFieldName) => Assign(overFieldName, (a, v) => a.OverFieldName = v);

		public RareDetectorDescriptor<T> OverFieldName(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.OverFieldName = v);

		public RareDetectorDescriptor<T> PartitionFieldName(Field partitionFieldName) => Assign(partitionFieldName, (a, v) => a.PartitionFieldName = v);

		public RareDetectorDescriptor<T> PartitionFieldName(Expression<Func<T, object>> objectPath) => Assign(objectPath, (a, v) => a.PartitionFieldName = v);
	}

	public class RareDetector : RareDetectorBase
	{
		public RareDetector() : base(RareFunction.Rare) { }
	}

	public class FreqRareDetector : RareDetectorBase
	{
		public FreqRareDetector() : base(RareFunction.FreqRare) { }
	}
}
