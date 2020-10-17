using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface ISchedule { }

	public abstract class ScheduleBase : ISchedule
	{
		internal abstract void WrapInContainer(IScheduleContainer container);
	}
}
