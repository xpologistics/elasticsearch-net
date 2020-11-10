﻿using System;
using System.Collections.Generic;

namespace Nest6
{
	public class DateHistogramBucket : KeyedBucket<double>
	{
		private static readonly long EpochTicks = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero).Ticks;

		public DateHistogramBucket(IReadOnlyDictionary<string, IAggregate> dict) : base(dict) { }

		// Get a DateTime form of the returned key
		public DateTime Date => new DateTime(EpochTicks + (long)Key * TimeSpan.TicksPerMillisecond, DateTimeKind.Utc);
	}
}
