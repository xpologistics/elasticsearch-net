﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<TimeOfYear>))]
	public interface ITimeOfYear
	{
		[JsonProperty("at")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<string>))]
		IEnumerable<string> At { get; set; }

		[JsonProperty("int")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<Month>))]
		IEnumerable<Month> In { get; set; }

		[JsonProperty("on")]
		[JsonConverter(typeof(ReadSingleOrEnumerableJsonConverter<int>))]
		IEnumerable<int> On { get; set; }
	}

	public class TimeOfYear : ITimeOfYear
	{
		public IEnumerable<string> At { get; set; }
		public IEnumerable<Month> In { get; set; }

		public IEnumerable<int> On { get; set; }
	}

	public class TimeOfYearDescriptor : DescriptorBase<TimeOfYearDescriptor, ITimeOfYear>, ITimeOfYear
	{
		IEnumerable<string> ITimeOfYear.At { get; set; }
		IEnumerable<Month> ITimeOfYear.In { get; set; }
		IEnumerable<int> ITimeOfYear.On { get; set; }

		public TimeOfYearDescriptor In(IEnumerable<Month> @in) => Assign(@in, (a, v) => a.In = v);

		public TimeOfYearDescriptor In(params Month[] @in) => Assign(@in, (a, v) => a.In = v);

		public TimeOfYearDescriptor On(IEnumerable<int> on) => Assign(on, (a, v) => a.On = v);

		public TimeOfYearDescriptor On(params int[] on) => Assign(on, (a, v) => a.On = v);

		public TimeOfYearDescriptor At(IEnumerable<string> time) => Assign(time, (a, v) => a.At = v);

		public TimeOfYearDescriptor At(params string[] time) => Assign(time, (a, v) => a.At = v);
	}
}
