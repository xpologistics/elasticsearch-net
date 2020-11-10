﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IEwmaModel : IMovingAverageModel
	{
		[JsonProperty("alpha")]
		float? Alpha { get; set; }
	}

	public class EwmaModel : IEwmaModel
	{
		public float? Alpha { get; set; }
		string IMovingAverageModel.Name { get; } = "ewma";
	}

	public class EwmaModelDescriptor
		: DescriptorBase<EwmaModelDescriptor, IEwmaModel>, IEwmaModel
	{
		float? IEwmaModel.Alpha { get; set; }
		string IMovingAverageModel.Name { get; } = "ewma";

		public EwmaModelDescriptor Alpha(float? alpha) => Assign(alpha, (a, v) => a.Alpha = v);
	}
}
