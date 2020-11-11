using System;

namespace Elasticsearch6.Net
{
	public interface IDateTimeProvider
	{
		DateTime Now();

		DateTime DeadTime(int attempts, TimeSpan? timeoutFactor, TimeSpan? maxDeadTimeout);
	}
}
