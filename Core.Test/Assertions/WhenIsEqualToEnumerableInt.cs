using System.Collections.Generic;
using WhenGivenThen.Assertions;
using Xunit;

namespace WhenGivenThen.Test.Assertions;

public abstract class WhenIsEqualToEnumerableInt : StaticSpec<object>
{
    protected IEnumerable<int> Actual;
    protected IEnumerable<int> Expected;

    protected WhenIsEqualToEnumerableInt() => When(() => Actual.IsEqualTo(Expected));

    public class Given_SameNumbers : WhenIsEqualToEnumerableInt
    {
        protected override void Set()
            => (Expected, Actual) = (new[] { 1, 2, 3 }, new[] { 1, 2, 3 });

        [Fact] public void Then_TheyAreEqual() => Then.NotThrows();
    }

    public class Given_SameNumbers_InDifferentOrder : WhenIsEqualToEnumerableInt
    {
        protected override void Set()
            => (Expected, Actual) = (new[] { 1, 2, 3 }, new[] { 1, 3, 2 });

        [Fact] public void Then_TheyAreNotEqual() => Then.Throws();
    }
}