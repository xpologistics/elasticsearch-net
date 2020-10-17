namespace Nest6
{
	public class PercolatorAttribute : ElasticsearchPropertyAttributeBase, IPercolatorProperty
	{
		public PercolatorAttribute() : base(FieldType.Percolator) { }
	}
}
