﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IHdfsRepository : IRepository<IHdfsRepositorySettings> { }

	public class HdfsRepository : IHdfsRepository
	{
		public HdfsRepository(HdfsRepositorySettings settings) => Settings = settings;

		public IHdfsRepositorySettings Settings { get; set; }
		object IRepositoryWithSettings.DelegateSettings => Settings;
		public string Type { get; } = "hdfs";
	}

	public interface IHdfsRepositorySettings : IRepositorySettings
	{
		[JsonProperty("chunk_size")]
		string ChunkSize { get; set; }

		[JsonProperty("compress")]
		bool? Compress { get; set; }

		[JsonProperty("concurrent_streams")]
		int? ConcurrentStreams { get; set; }

		[JsonProperty("conf_location")]
		string ConfigurationLocation { get; set; }

		[JsonIgnore]
		Dictionary<string, object> InlineHadoopConfiguration { get; set; }

		[JsonProperty("load_defaults")]
		bool? LoadDefaults { get; set; }

		[JsonProperty("path")]
		string Path { get; set; }

		[JsonProperty("uri")]
		string Uri { get; set; }
	}

	public class HdfsRepositorySettings : IHdfsRepositorySettings
	{
		internal HdfsRepositorySettings() { }

		public HdfsRepositorySettings(string path) => Path = path;

		public string ChunkSize { get; set; }
		public bool? Compress { get; set; }
		public int? ConcurrentStreams { get; set; }
		public string ConfigurationLocation { get; set; }
		public Dictionary<string, object> InlineHadoopConfiguration { get; set; }
		public bool? LoadDefaults { get; set; }
		public string Path { get; set; }
		public string Uri { get; set; }
	}

	public class HdfsRepositorySettingsDescriptor
		: DescriptorBase<HdfsRepositorySettingsDescriptor, IHdfsRepositorySettings>, IHdfsRepositorySettings
	{
		string IHdfsRepositorySettings.ChunkSize { get; set; }
		bool? IHdfsRepositorySettings.Compress { get; set; }
		int? IHdfsRepositorySettings.ConcurrentStreams { get; set; }
		string IHdfsRepositorySettings.ConfigurationLocation { get; set; }
		Dictionary<string, object> IHdfsRepositorySettings.InlineHadoopConfiguration { get; set; }
		bool? IHdfsRepositorySettings.LoadDefaults { get; set; }
		string IHdfsRepositorySettings.Path { get; set; }
		string IHdfsRepositorySettings.Uri { get; set; }

		/// <summary>
		/// optional - Hadoop file-system URI
		/// </summary>
		public HdfsRepositorySettingsDescriptor Uri(string uri) => Assign(uri, (a, v) => a.Uri = v);

		/// <summary>
		/// required - path with the file-system where data is stored/loaded
		/// </summary>
		public HdfsRepositorySettingsDescriptor Path(string path) => Assign(path, (a, v) => a.Path = v);

		/// <summary>
		/// whether to load the default Hadoop configuration (default) or not
		/// </summary>
		/// <param name="loadDefaults"></param>
		public HdfsRepositorySettingsDescriptor LoadDefaults(bool? loadDefaults = true) => Assign(loadDefaults, (a, v) => a.LoadDefaults = v);

		/// <summary>
		/// Hadoop configuration XML to be loaded (use commas for multi values)
		/// </summary>
		/// <param name="configurationLocation"></param>
		public HdfsRepositorySettingsDescriptor ConfigurationLocation(string configurationLocation) =>
			Assign(configurationLocation, (a, v) => a.ConfigurationLocation = v);

		/// <summary>
		/// 'inlined' key=value added to the Hadoop configuration
		/// </summary>
		public HdfsRepositorySettingsDescriptor InlinedHadoopConfiguration(
			Func<FluentDictionary<string, object>, FluentDictionary<string, object>> inlineConfig
		) => Assign(inlineConfig, (a, v) => a.InlineHadoopConfiguration = v(new FluentDictionary<string, object>()));

		/// <summary>
		/// When set to true metadata files are stored in compressed format. This setting doesn't
		/// affect index files that are already compressed by default. Defaults to false.
		/// </summary>
		/// <param name="compress"></param>
		public HdfsRepositorySettingsDescriptor Compress(bool? compress = true) => Assign(compress, (a, v) => a.Compress = v);

		/// <summary>
		/// Throttles the number of streams (per node) preforming snapshot operation. Defaults to 5
		/// </summary>
		/// <param name="concurrentStreams"></param>
		public HdfsRepositorySettingsDescriptor ConcurrentStreams(int? concurrentStreams) => Assign(concurrentStreams, (a, v) => a.ConcurrentStreams = v);

		/// <summary>
		///  Big files can be broken down into chunks during snapshotting if needed.
		///  The chunk size can be specified in bytes or by using size value notation,
		///  i.e. 1g, 10m, 5k. Disabled by default
		/// </summary>
		/// <param name="chunkSize"></param>
		public HdfsRepositorySettingsDescriptor ChunkSize(string chunkSize) => Assign(chunkSize, (a, v) => a.ChunkSize = v);
	}

	public class HdfsRepositoryDescriptor
		: DescriptorBase<HdfsRepositoryDescriptor, IHdfsRepository>, IHdfsRepository
	{
		IHdfsRepositorySettings IRepository<IHdfsRepositorySettings>.Settings { get; set; }
		object IRepositoryWithSettings.DelegateSettings => Self.Settings;
		string ISnapshotRepository.Type => "hdfs";

		public HdfsRepositoryDescriptor Settings(string path, Func<HdfsRepositorySettingsDescriptor, IHdfsRepositorySettings> settingsSelector = null
		) =>
			Assign(settingsSelector.InvokeOrDefault(new HdfsRepositorySettingsDescriptor().Path(path)), (a, v) => a.Settings = v);
	}
}
