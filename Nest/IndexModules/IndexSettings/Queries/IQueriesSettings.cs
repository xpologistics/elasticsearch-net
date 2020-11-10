using System;

namespace Nest6
{
	public interface IQueriesSettings
	{
		IQueriesCacheSettings Cache { get; set; }
	}

	public class QueriesSettings : IQueriesSettings
	{
		public IQueriesCacheSettings Cache { get; set; }
	}

	public class QueriesSettingsDescriptor : DescriptorBase<QueriesSettingsDescriptor, IQueriesSettings>, IQueriesSettings
	{
		IQueriesCacheSettings IQueriesSettings.Cache { get; set; }

		/// <inheritdoc />
		public QueriesSettingsDescriptor Cache(Func<QueriesCacheSettingsDescriptor, IQueriesCacheSettings> selector) =>
			Assign(selector.Invoke(new QueriesCacheSettingsDescriptor()), (a, v) => a.Cache = v);
	}
}
