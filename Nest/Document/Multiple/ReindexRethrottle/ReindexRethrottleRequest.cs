﻿using System;

namespace Nest6
{
	public partial interface IReindexRethrottleRequest { }

	public partial class ReindexRethrottleRequest : IReindexRethrottleRequest { }

	public partial class ReindexRethrottleDescriptor : IReindexRethrottleRequest
	{
		[Obsolete("Maintained for binary compatibility. Use the constructor that accepts a task id. Will be removed in 7.0")]
		public ReindexRethrottleDescriptor() { }

		public ReindexRethrottleDescriptor TaskId(TaskId id)
		{
			RequestState.RouteValues.Required("task_id", id);
			return this;
		}
	}
}
