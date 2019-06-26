using System.Buffers;

namespace Elasticsearch.Net.Utf8Json
{
	/// <summary>
	/// A shared array pool of byte arrays used for serialization
	/// </summary>
	internal static class SharedByteArrayPool
	{
		/// <summary>
		/// Retrieves a buffer that is at least the requested length
		/// </summary>
		public static byte[] Rent(int minLength = 1024) => ArrayPool<byte>.Shared.Rent(minLength);

		/// <summary>
		/// Returns an array to the pool that was previously obtain using <see cref="Rent"/>
		/// </summary>
		public static void Return(byte[] bytes) => ArrayPool<byte>.Shared.Return(bytes);
	}
}
