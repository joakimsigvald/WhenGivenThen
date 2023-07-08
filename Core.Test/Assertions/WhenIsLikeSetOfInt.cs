using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WhenGivenThen.Test.Assertions;

public abstract class WhenIsLikeSetOfInt : TestStatic<object>
{
    protected ISet<int> Actual;
    protected ISet<int> Expected;

    protected WhenIsLikeSetOfInt() => When(() => Actual.IsLike(Expected));

    public class Given_SameNumbers : WhenIsLikeSetOfInt
    {
        protected override void Set()
            => (Expected, Actual) = (new[] { 1, 2, 3 }.ToHashSet(), new[] { 1, 2, 3 }.ToHashSet());

        [Fact] public void Then_TheyAreEqual() => Then.NotThrows();
    }

    public class Given_SameNumbers_InDifferentOrder : WhenIsLikeSetOfInt
    {
        protected override void Set()
            => (Expected, Actual) = (new[] { 1, 2, 3 }.ToHashSet(), new[] { 1, 3, 2 }.ToHashSet());

        [Fact] public void Then_TheyAreEqual() => Then.NotThrows();
    }

    public class Given_DifferentNumbers : WhenIsLikeSetOfInt
    {
        protected override void Set()
            => (Expected, Actual) = (new[] { 1, 2, 3 }.ToHashSet(), new[] { 1, 3, 4 }.ToHashSet());

        [Fact] public void Then_TheyAreNotEqual() => Then.Throws();
    }
}