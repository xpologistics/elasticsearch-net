namespace Nest6
{
	internal class IndexJsonConverter : DocumentProxyRequestConverterBase
	{
		public IndexJsonConverter() : base(typeof(IndexRequest<>)) { }
	}
}
