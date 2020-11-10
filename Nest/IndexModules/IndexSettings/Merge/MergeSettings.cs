using System;

namespace Nest6
{
	public interface IMergeSettings
	{
		IMergePolicySettings Policy { get; set; }
		IMergeSchedulerSettings Scheduler { get; set; }
	}

	public class MergeSettings : IMergeSettings
	{
		/// <inheritdoc />
		public IMergePolicySettings Policy { get; set; }

		/// <inheritdoc />
		public IMergeSchedulerSettings Scheduler { get; set; }
	}

	public class MergeSettingsDescriptor
		: DescriptorBase<MergeSettingsDescriptor, IMergeSettings>, IMergeSettings
	{
		IMergePolicySettings IMergeSettings.Policy { get; set; }
		IMergeSchedulerSettings IMergeSettings.Scheduler { get; set; }

		/// <inheritdoc />
		public MergeSettingsDescriptor Policy(Func<MergePolicySettingsDescriptor, IMergePolicySettings> selector) =>
			Assign(selector, (a, v) => a.Policy = v?.Invoke(new MergePolicySettingsDescriptor()));

		/// <inheritdoc />
		public MergeSettingsDescriptor Scheduler(Func<MergeSchedulerSettingsDescriptor, IMergeSchedulerSettings> selector) =>
			Assign(selector, (a, v) => a.Scheduler = v?.Invoke(new MergeSchedulerSettingsDescriptor()));
	}
}
