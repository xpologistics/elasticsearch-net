using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<AlwaysCondition>))]
	public interface IAlwaysCondition : ICondition { }

	public class AlwaysCondition : ConditionBase, IAlwaysCondition
	{
		internal override void WrapInContainer(IConditionContainer container) => container.Always = this;
	}
}
