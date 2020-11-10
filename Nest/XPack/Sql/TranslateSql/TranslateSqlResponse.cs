namespace Nest6
{
	public interface ITranslateSqlResponse : IResponse
	{
		ISearchRequest Result { get; }
	}

	public class TranslateSqlResponse : ResponseBase, ITranslateSqlResponse
	{
		public ISearchRequest Result { get; internal set; }
	}
}
