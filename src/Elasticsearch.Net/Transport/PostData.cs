using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Elasticsearch.Net
{
	public interface IPostData
	{
		void Write(Stream writableStream, IConnectionConfigurationValues settings);

		Task WriteAsync(Stream writableStream, IConnectionConfigurationValues settings, CancellationToken cancellationToken);
	}

	public interface IPostData<out T> : IPostData { }

	public enum PostType
	{
		ByteArray,
		LiteralString,
		EnumerableOfString,
		EnumerableOfObject,
		Serializable
	}

	public abstract class PostData
	{
		protected const int BufferSize = 81920;
		protected static readonly byte[] NewLineByteArray = { (byte)'\n' };
		protected const string NewLineString = "\n";

		public bool? DisableDirectStreaming { get; set; }
		public byte[] WrittenBytes { get; protected set; }
		public PostType Type { get; protected set; }

		public abstract void Write(Stream writableStream, IConnectionConfigurationValues settings);

		public abstract Task WriteAsync(Stream writableStream, IConnectionConfigurationValues settings, CancellationToken cancellationToken);

		public static implicit operator PostData(byte[] byteArray) => PostData.Bytes(byteArray);
		public static implicit operator PostData(string literalString) => PostData.String(literalString);

		public static SerializableData<T> Serializable<T>(T o) => new SerializableData<T>(o);
		public static PostData MultiJson(IEnumerable<string> listOfString) => new PostData<IEnumerable<string>>(listOfString);
		public static PostData MultiJson(IEnumerable<object> listOfObjects) => new PostData<IEnumerable<object>>(listOfObjects);
		public static PostData Bytes(byte[] bytes) => new PostData<byte[]>(bytes);
		public static PostData String(string serializedString) => new PostData<string>(serializedString);
	}

	public class PostData<T> : PostData, IPostData<T>
	{
		private readonly string _literalString;
		private readonly IEnumerable<string> _enumurableOfStrings;
		private readonly IEnumerable<object> _enumerableOfObject;

		protected internal PostData(byte[] item) { WrittenBytes = item; Type = PostType.ByteArray; }
		protected internal PostData(string item) { _literalString = item; Type = PostType.LiteralString; }
		protected internal PostData(IEnumerable<string> item) { _enumurableOfStrings = item; Type = PostType.EnumerableOfString; }
		protected internal PostData(IEnumerable<object> item) { _enumerableOfObject = item; Type = PostType.EnumerableOfObject; }

		private PostData() { }

		public override void Write(Stream writableStream, IConnectionConfigurationValues settings)
		{
			MemoryStream ms = null;
			switch (Type)
			{
				case PostType.ByteArray:
					ms = settings.MemoryStreamFactory.Create(WrittenBytes);
					break;
				case PostType.LiteralString:
					ms = !string.IsNullOrEmpty(_literalString)
						? settings.MemoryStreamFactory.Create(_literalString?.Utf8Bytes())
						: null;
					break;
				case PostType.EnumerableOfString:
					ms = _enumurableOfStrings.HasAny()
						? settings.MemoryStreamFactory.Create((string.Join(NewLineString, _enumurableOfStrings) + NewLineString).Utf8Bytes())
						: null;
					break;
				case PostType.EnumerableOfObject:
					if (!_enumerableOfObject.HasAny()) return;
					Stream stream = null;
					if (this.DisableDirectStreaming ?? settings.DisableDirectStreaming)
					{
						ms = settings.MemoryStreamFactory.Create();
						stream = ms;
					}
					else stream = writableStream;
					foreach (var o in _enumerableOfObject)
					{
						settings.RequestResponseSerializer.Serialize(o, stream, SerializationFormatting.None);
						stream.Write(NewLineByteArray, 0, 1);
					}
					break;
			}
			if (ms != null)
			{
				ms.Position = 0;
				ms.CopyTo(writableStream, BufferSize);
			}
			if (this.Type != 0)
				this.WrittenBytes = ms?.ToArray();
		}

		public override async Task WriteAsync(Stream writableStream, IConnectionConfigurationValues settings, CancellationToken cancellationToken)
		{
			MemoryStream ms = null;
			switch (Type)
			{
				case PostType.ByteArray:
					ms = settings.MemoryStreamFactory.Create(WrittenBytes);
					break;
				case PostType.LiteralString:
					ms = !string.IsNullOrEmpty(_literalString)
						? settings.MemoryStreamFactory.Create(_literalString.Utf8Bytes())
						: null;
					break;
				case PostType.EnumerableOfString:
					ms = _enumurableOfStrings.HasAny()
						? settings.MemoryStreamFactory.Create((string.Join(NewLineString, _enumurableOfStrings) + NewLineString).Utf8Bytes())
						: null;
					break;
				case PostType.EnumerableOfObject:
					if (!_enumerableOfObject.HasAny()) return;
					Stream stream = null;
					if (this.DisableDirectStreaming ?? settings.DisableDirectStreaming)
					{
						ms = settings.MemoryStreamFactory.Create();
						stream = ms;
					}
					else stream = writableStream;
					foreach (var o in _enumerableOfObject)
					{
						await settings.RequestResponseSerializer.SerializeAsync(o, stream, SerializationFormatting.None, cancellationToken).ConfigureAwait(false);
						await stream.WriteAsync(NewLineByteArray, 0, 1, cancellationToken).ConfigureAwait(false);
					}
					break;
			}
			if (ms != null)
			{
				ms.Position = 0;
				await ms.CopyToAsync(writableStream, BufferSize, cancellationToken).ConfigureAwait(false);
			}
			if (this.Type != 0)
				this.WrittenBytes = ms?.ToArray();
		}
	}
}
