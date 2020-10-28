using System.Collections.Generic;
using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest6;

namespace Tests.Analysis.CharFilters
{
	public interface ICharFilterAssertion : IAnalysisAssertion<ICharFilter, ICharFilters, CharFiltersDescriptor> { }

	public abstract class CharFilterAssertionBase<TAssertion>
		: AnalysisComponentTestBase<TAssertion, ICharFilter, ICharFilters, CharFiltersDescriptor>
			, ICharFilterAssertion
		where TAssertion : CharFilterAssertionBase<TAssertion>, new()
	{
		protected override object AnalysisJson => new
		{
			char_filter = new Dictionary<string, object> { { AssertionSetup.Name, AssertionSetup.Json } }
		};

		protected override IAnalysis FluentAnalysis(AnalysisDescriptor an) =>
			an.CharFilters(d => AssertionSetup.Fluent(AssertionSetup.Name, d));

		protected override Nest6.Analysis InitializerAnalysis() =>
			new Nest6.Analysis { CharFilters = new Nest6.CharFilters { { AssertionSetup.Name, AssertionSetup.Initializer } } };

		// https://youtrack.jetbrains.com/issue/RIDER-19912
		[U] public override Task TestPutSettingsRequest() => base.TestPutSettingsRequest();

		[I] public override Task TestPutSettingsResponse() => base.TestPutSettingsResponse();
	}
}
