﻿using System;

namespace Nest6
{
	public partial interface IGetTaskRequest { }

	public partial class GetTaskRequest { }

	[DescriptorFor("TasksGet")]
	public partial class GetTaskDescriptor
	{
		[Obsolete("Maintained for binary compatibility. Use the constructor that accepts a task id. Will be removed in 7.0")]
		public GetTaskDescriptor() { }

		[Obsolete("Maintained for binary compatibility. Use the constructor that accepts a task id. Will be removed in 7.0")]
		public GetTaskDescriptor TaskId(TaskId taskId) => Assign(taskId, (a, v) => a.RouteValues.Required("task_id", v));
	}
}
