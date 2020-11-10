using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface ICondition { }

	public abstract class ConditionBase : ICondition
	{
		internal abstract void WrapInContainer(IConditionContainer container);
	}
}
