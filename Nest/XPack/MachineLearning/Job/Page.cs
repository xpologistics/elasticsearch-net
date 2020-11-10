using Newtonsoft.Json;

namespace Nest6
{
	public interface IPage
	{
		/// <summary>
		/// Skips the specified number of buckets.
		/// </summary>
		[JsonProperty("from")]
		int? From { get; set; }

		/// <summary>
		/// Specifies the maximum number of buckets to obtain.
		/// </summary>
		[JsonProperty("size")]
		int? Size { get; set; }
	}

	public class Page : IPage
	{
		/// <inheritdoc />
		public int? From { get; set; }

		/// <inheritdoc />
		public int? Size { get; set; }
	}

	public class PageDescriptor : DescriptorBase<PageDescriptor, IPage>, IPage
	{
		int? IPage.From { get; set; }
		int? IPage.Size { get; set; }

		/// <inheritdoc />
		public PageDescriptor From(int? from) => Assign(from, (a, v) => a.From = v);

		/// <inheritdoc />
		public PageDescriptor Size(int? size) => Assign(size, (a, v) => a.Size = v);
	}
}
