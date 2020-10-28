using Elastic.Xunit.XunitPlumbing;
using FluentAssertions;
using Tests.Core.Extensions;
using Tests.Domain;

namespace Tests.ClientConcepts.HighLevel.Inference.Equality
{
	public class IndicesEqualityTests
	{
		[U] public void Eq()
		{
			Nest6.Indices types = "foo,bar";
			Nest6.Indices[] equal = { "foo,bar", "bar,foo", "foo,  bar", "bar,  foo   " };
			foreach (var t in equal)
			{
				(t == types).ShouldBeTrue(t);
				t.Should().Be(types);
			}

			(Nest6.Indices.All == "_all").Should().BeTrue();
		}


		[U] public void NotEq()
		{
			Nest6.Indices types = "foo,bar";
			Nest6.Indices[] notEqual = { "foo,bar,x", "foo", typeof(Project) };
			foreach (var t in notEqual)
			{
				(t != types).ShouldBeTrue(t);
				t.Should().NotBe(types);
			}
		}

		[U] public void TypedEq()
		{
			Nest6.Indices t1 = typeof(Project), t2 = typeof(Project);
			(t1 == t2).ShouldBeTrue(t2);
		}

		[U] public void TypedNotEq()
		{
			Nest6.Indices t1 = typeof(Project), t2 = typeof(CommitActivity);
			(t1 != t2).ShouldBeTrue(t2);
		}

		[U] public void Null()
		{
			Nest6.Indices value = typeof(Project);
			(value == null).Should().BeFalse();
			(null == value).Should().BeFalse();
		}
	}
}
