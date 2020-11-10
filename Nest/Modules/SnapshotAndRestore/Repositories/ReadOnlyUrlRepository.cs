﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IReadOnlyUrlRepository : IRepository<IReadOnlyUrlRepositorySettings> { }

	public class ReadOnlyUrlRepository : IReadOnlyUrlRepository
	{
		public ReadOnlyUrlRepository(ReadOnlyUrlRepositorySettings settings) => Settings = settings;

		public IReadOnlyUrlRepositorySettings Settings { get; set; }
		object IRepositoryWithSettings.DelegateSettings => Settings;
		public string Type { get; } = "url";
	}

	public interface IReadOnlyUrlRepositorySettings : IRepositorySettings
	{
		[JsonProperty("concurrent_streams")]
		int? ConcurrentStreams { get; set; }

		[JsonProperty("location")]
		string Location { get; set; }
	}

	public class ReadOnlyUrlRepositorySettings : IReadOnlyUrlRepositorySettings
	{
		internal ReadOnlyUrlRepositorySettings() { }

		public ReadOnlyUrlRepositorySettings(string location) => Location = location;

		public int? ConcurrentStreams { get; set; }

		public string Location { get; set; }
	}

	public class ReadOnlyUrlRepositorySettingsDescriptor
		: DescriptorBase<ReadOnlyUrlRepositorySettingsDescriptor, IReadOnlyUrlRepositorySettings>, IReadOnlyUrlRepositorySettings
	{
		int? IReadOnlyUrlRepositorySettings.ConcurrentStreams { get; set; }
		string IReadOnlyUrlRepositorySettings.Location { get; set; }

		/// <summary>
		/// Location of the snapshots. Mandatory.
		/// </summary>
		/// <param name="location"></param>
		public ReadOnlyUrlRepositorySettingsDescriptor Location(string location) => Assign(location, (a, v) => a.Location = v);

		/// <summary>
		/// Throttles the number of streams (per node) preforming snapshot operation. Defaults to 5
		/// </summary>
		/// <param name="concurrentStreams"></param>
		public ReadOnlyUrlRepositorySettingsDescriptor ConcurrentStreams(int? concurrentStreams) =>
			Assign(concurrentStreams, (a, v) => a.ConcurrentStreams = v);
	}

	public class ReadOnlyUrlRepositoryDescriptor
		: DescriptorBase<ReadOnlyUrlRepositoryDescriptor, IReadOnlyUrlRepository>, IReadOnlyUrlRepository
	{
		IReadOnlyUrlRepositorySettings IRepository<IReadOnlyUrlRepositorySettings>.Settings { get; set; }
		object IRepositoryWithSettings.DelegateSettings => Self.Settings;
		string ISnapshotRepository.Type => "url";

		public ReadOnlyUrlRepositoryDescriptor Settings(string location,
			Func<ReadOnlyUrlRepositorySettingsDescriptor, IReadOnlyUrlRepositorySettings> settingsSelector = null
		) =>
			Assign(settingsSelector.InvokeOrDefault(new ReadOnlyUrlRepositorySettingsDescriptor().Location(location)), (a, v) => a.Settings = v);
	}
}
