namespace Nest6
{
	internal class CreateJsonConverter : DocumentProxyRequestConverterBase
	{
		public CreateJsonConverter() : base(typeof(CreateRequest<>)) { }
	}
}
