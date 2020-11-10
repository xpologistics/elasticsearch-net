﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<TimeOfDay>))]
	public interface ITimeOfDay
	{
		[JsonProperty("hour")]
		IEnumerable<int> Hour { get; set; }

		[JsonProperty("minute")]
		IEnumerable<int> Minute { get; set; }
	}

	public class TimeOfDay : ITimeOfDay
	{
		public IEnumerable<int> Hour { get; set; }
		public IEnumerable<int> Minute { get; set; }
	}

	public class TimeOfDayDescriptor : DescriptorBase<TimeOfDayDescriptor, ITimeOfDay>, ITimeOfDay
	{
		IEnumerable<int> ITimeOfDay.Hour { get; set; }
		IEnumerable<int> ITimeOfDay.Minute { get; set; }

		public TimeOfDayDescriptor Hour(IEnumerable<int> hours) => Assign(hours, (a, v) => a.Hour = v);

		public TimeOfDayDescriptor Hour(params int[] hours) => Assign(hours, (a, v) => a.Hour = v);

		public TimeOfDayDescriptor Minute(IEnumerable<int> minutes) => Assign(minutes, (a, v) => a.Minute = v);

		public TimeOfDayDescriptor Minute(params int[] minutes) => Assign(minutes, (a, v) => a.Minute = v);
	}

	[JsonObject]
	public interface IDailySchedule : ISchedule
	{
		[JsonProperty("at")]
		Union<IEnumerable<string>, ITimeOfDay> At { get; set; }
	}

	public class DailySchedule : ScheduleBase, IDailySchedule
	{
		public Union<IEnumerable<string>, ITimeOfDay> At { get; set; }

		internal override void WrapInContainer(IScheduleContainer container) => container.Daily = this;
	}

	public class DailyScheduleDescriptor : DescriptorBase<DailyScheduleDescriptor, IDailySchedule>, IDailySchedule
	{
		Union<IEnumerable<string>, ITimeOfDay> IDailySchedule.At { get; set; }

		public DailyScheduleDescriptor At(Func<TimeOfDayDescriptor, ITimeOfDay> selector) =>
			Assign(selector, (a, v) => a.At = new Union<IEnumerable<string>, ITimeOfDay>(v?.InvokeOrDefault(new TimeOfDayDescriptor())));

		public DailyScheduleDescriptor At(IEnumerable<string> times) =>
			Assign(new Union<IEnumerable<string>, ITimeOfDay>(times), (a, v) => a.At = v);

		public DailyScheduleDescriptor At(params string[] times) =>
			Assign(new Union<IEnumerable<string>, ITimeOfDay>(times), (a, v) => a.At = v);
	}
}
