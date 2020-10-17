using Newtonsoft.Json;

namespace Nest6
{
	public interface ISnapshotRepository
	{
		[JsonProperty("type")]
		string Type { get; }
	}

	public interface IRepositoryWithSettings: ISnapshotRepository
	{
		[JsonIgnore]
		object DelegateSettings { get; }
	}

	public interface IRepository<TSettings> : IRepositoryWithSettings
		where TSettings : class, IRepositorySettings
	{
		[JsonProperty("settings")]
		TSettings Settings { get; set; }
	}

	public interface IRepositorySettings { }
}
