using System.Collections.Generic;

namespace Nest6
{
	public class TermsOrderDescriptor<T> : DescriptorPromiseBase<TermsOrderDescriptor<T>, IList<TermsOrder>>
		where T : class
	{
		public TermsOrderDescriptor() : base(new List<TermsOrder>()) { }

		public TermsOrderDescriptor<T> CountAscending() => Assign(a => a.Add(TermsOrder.CountAscending));

		public TermsOrderDescriptor<T> CountDescending() => Assign(a => a.Add(TermsOrder.CountDescending));

		public TermsOrderDescriptor<T> KeyAscending() => Assign(a => a.Add(TermsOrder.KeyAscending));

		public TermsOrderDescriptor<T> KeyDescending() => Assign(a => a.Add(TermsOrder.KeyDescending));

		public TermsOrderDescriptor<T> Ascending(string key) =>
			string.IsNullOrWhiteSpace(key) ? this : Assign(key,(a, v) => a.Add(new TermsOrder { Key = v, Order = SortOrder.Ascending }));

		public TermsOrderDescriptor<T> Descending(string key) =>
			string.IsNullOrWhiteSpace(key) ? this : Assign(key,(a, v) => a.Add(new TermsOrder { Key = v, Order = SortOrder.Descending }));
	}
}
