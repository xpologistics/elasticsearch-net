using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IGetBucketsResponse : IResponse
	{
		[JsonProperty("buckets")]
		IReadOnlyCollection<Bucket> Buckets { get; }

		[JsonProperty("count")]
		long Count { get; }
	}

	public class GetBucketsResponse : ResponseBase, IGetBucketsResponse
	{
		public IReadOnlyCollection<Bucket> Buckets { get; internal set; } = EmptyReadOnly<Bucket>.Collection;
		public long Count { get; internal set; }
	}
}
