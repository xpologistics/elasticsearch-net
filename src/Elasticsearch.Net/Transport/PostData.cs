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
		protected const byte NewLineByte = (byte)'\n';
		// TODO: Remove in NEST 7.x
		protected static readonly byte[] NewLineByteArray = { NewLineByte };
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
			var disableDirectStreaming = this.DisableDirectStreaming ?? settings.DisableDirectStreaming;
			switch (Type)
			{
				case PostType.ByteArray:
					writableStream.Write(WrittenBytes, 0, WrittenBytes.Length);
					break;
				case PostType.LiteralString:
					if (_literalString != null)
					{
						var bytes = _literalString.Utf8Bytes();
						writableStream.Write(bytes, 0, bytes.Length);
						WrittenBytes = bytes;
					}
					break;
				case PostType.EnumerableOfString:
					if (_enumurableOfStrings != null)
					{
						var bytes = (string.Join(NewLineString, _enumurableOfStrings) + NewLineString).Utf8Bytes();
						writableStream.Write(bytes, 0, bytes.Length);
						WrittenBytes = bytes;
					}
					break;
				case PostType.EnumerableOfObject:
					if (_enumerableOfObject != null)
					{
						MemoryStream ms = null;

						if (disableDirectStreaming)
							ms = settings.MemoryStreamFactory.Create();

						var stream = ms ?? writableStream;

						foreach (var o in _enumerableOfObject)
						{
							settings.RequestResponseSerializer.Serialize(o, stream, SerializationFormatting.None);
							stream.WriteByte(NewLineByte);
						}

						if (ms != null)
						{
							ms.Position = 0;
							ms.CopyTo(writableStream, BufferSize);
							WrittenBytes = ms.ToArray();
						}
					}
					break;
			}
		}

		public override async Task WriteAsync(Stream writableStream, IConnectionConfigurationValues settings, CancellationToken cancellationToken)
		{
			var disableDirectStreaming = this.DisableDirectStreaming ?? settings.DisableDirectStreaming;
			switch (Type)
			{
				case PostType.ByteArray:
					await writableStream.WriteAsync(WrittenBytes, 0, WrittenBytes.Length, cancellationToken).ConfigureAwait(false);
					break;
				case PostType.LiteralString:
					if (_literalString != null)
					{
						var bytes = _literalString.Utf8Bytes();
						await writableStream.WriteAsync(bytes, 0, bytes.Length, cancellationToken).ConfigureAwait(false);
						WrittenBytes = bytes;
					}
					break;
				case PostType.EnumerableOfString:
					if (_enumurableOfStrings != null)
					{
						var bytes = (string.Join(NewLineString, _enumurableOfStrings) + NewLineString).Utf8Bytes();
						await writableStream.WriteAsync(bytes, 0, bytes.Length, cancellationToken).ConfigureAwait(false);
						WrittenBytes = bytes;
					}
					break;
				case PostType.EnumerableOfObject:
					if (_enumerableOfObject != null)
					{
						MemoryStream ms = null;
						if (disableDirectStreaming)
							ms = settings.MemoryStreamFactory.Create();

						var stream = ms ?? writableStream;

						foreach (var o in _enumerableOfObject)
						{
							await settings.RequestResponseSerializer.SerializeAsync(o, stream, SerializationFormatting.None, cancellationToken).ConfigureAwait(false);
							stream.WriteByte(NewLineByte);
						}

						if (ms != null)
						{
							ms.Position = 0;
							await ms.CopyToAsync(writableStream, BufferSize, cancellationToken).ConfigureAwait(false);
							WrittenBytes = ms.ToArray();
						}
					}
					break;
			}
		}
	}
}
