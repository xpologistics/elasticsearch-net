﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IAzureRepository : IRepository<IAzureRepositorySettings> { }

	public class AzureRepository : IAzureRepository
	{
		public AzureRepository() { }

		public AzureRepository(IAzureRepositorySettings settings) => Settings = settings;

		public IAzureRepositorySettings Settings { get; set; }
		object IRepositoryWithSettings.DelegateSettings => Settings;
		public string Type { get; } = "azure";
	}

	public interface IAzureRepositorySettings : IRepositorySettings
	{
		[JsonProperty("base_path")]
		string BasePath { get; set; }

		[JsonProperty("chunk_size")]
		string ChunkSize { get; set; }

		[JsonProperty("compress")]
		bool? Compress { get; set; }

		[JsonProperty("container")]
		string Container { get; set; }
	}

	public class AzureRepositorySettings : IAzureRepositorySettings
	{
		[JsonProperty("base_path")]
		public string BasePath { get; set; }

		[JsonProperty("chunk_size")]
		public string ChunkSize { get; set; }

		[JsonProperty("compress")]
		public bool? Compress { get; set; }

		[JsonProperty("container")]
		public string Container { get; set; }
	}

	public class AzureRepositorySettingsDescriptor
		: DescriptorBase<AzureRepositorySettingsDescriptor, IAzureRepositorySettings>, IAzureRepositorySettings
	{
		string IAzureRepositorySettings.BasePath { get; set; }
		string IAzureRepositorySettings.ChunkSize { get; set; }
		bool? IAzureRepositorySettings.Compress { get; set; }
		string IAzureRepositorySettings.Container { get; set; }

		/// <summary>
		/// Container name. Defaults to elasticsearch-snapshots
		/// </summary>
		/// <param name="container"></param>
		public AzureRepositorySettingsDescriptor Container(string container) => Assign(container, (a, v) => a.Container = v);

		/// <summary>
		/// Specifies the path within container to repository data. Defaults to empty (root directory).
		/// </summary>
		/// <param name="basePath"></param>
		/// <returns></returns>
		public AzureRepositorySettingsDescriptor BasePath(string basePath) => Assign(basePath, (a, v) => a.BasePath = v);

		/// <summary>
		/// When set to true metadata files are stored in compressed format. This setting doesn't
		/// affect index files that are already compressed by default. Defaults to false.
		/// </summary>
		/// <param name="compress"></param>
		public AzureRepositorySettingsDescriptor Compress(bool? compress = true) => Assign(compress, (a, v) => a.Compress = v);

		/// <summary>
		///  Big files can be broken down into chunks during snapshotting if needed.
		///  The chunk size can be specified in bytes or by using size value notation,
		///  i.e. 1g, 10m, 5k. Defaults to 64m (64m max)
		/// </summary>
		/// <param name="chunkSize"></param>
		public AzureRepositorySettingsDescriptor ChunkSize(string chunkSize) => Assign(chunkSize, (a, v) => a.ChunkSize = v);
	}

	public class AzureRepositoryDescriptor
		: DescriptorBase<AzureRepositoryDescriptor, IAzureRepository>, IAzureRepository
	{
		IAzureRepositorySettings IRepository<IAzureRepositorySettings>.Settings { get; set; }
		string ISnapshotRepository.Type { get; } = "azure";
		object IRepositoryWithSettings.DelegateSettings => Self.Settings;

		public AzureRepositoryDescriptor Settings(Func<AzureRepositorySettingsDescriptor, IAzureRepositorySettings> settingsSelector) =>
			Assign(settingsSelector, (a, v) => a.Settings = v?.Invoke(new AzureRepositorySettingsDescriptor()));
	}
}
