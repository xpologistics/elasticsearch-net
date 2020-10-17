using System.Collections.Generic;

namespace Nest6
{
	public interface IPreviewDatafeedResponse<T> : IResponse
	{
		IReadOnlyCollection<T> Data { get; }
	}

	public class PreviewDatafeedResponse<T> : ResponseBase, IPreviewDatafeedResponse<T>
	{
		public IReadOnlyCollection<T> Data { get; internal set; } = EmptyReadOnly<T>.Collection;
	}
}
