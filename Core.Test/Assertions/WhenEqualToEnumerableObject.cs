using System.Collections.Generic;
using System.Linq;
using WhenGivenThen.Test.Subjects;
using Xunit;

namespace WhenGivenThen.Test.Assertions;

public abstract class WhenEqualToEnumerableObject : TestStatic<object>
{
    protected IEnumerable<ShoppingCart> Actual;
    protected IEnumerable<ShoppingCart> Expected;

    protected WhenEqualToEnumerableObject() => When(() => Actual.IsEqualTo(Expected));

    public class Given_SameNumbers : WhenEqualToEnumerableObject
    {
        protected override void Set()
        {
            Expected = new[] { 1, 2, 3 }.Select(id => new ShoppingCart { Id = id }).ToArray();
            Actual = new[] { 1, 2, 3 }.Select(id => new ShoppingCart { Id = id }).ToArray();
        }

        [Fact] public void Then_TheyAreEqual() => Then.NotThrows();
    }

    public class Given_SameNumbers_InDifferentOrder : WhenEqualToEnumerableObject
    {
        protected override void Set()
        {
            Expected = new[] { 1, 2, 3 }.Select(id => new ShoppingCart { Id = id }).ToArray();
            Actual = new[] { 1, 3, 2 }.Select(id => new ShoppingCart { Id = id }).ToArray();
        }

        [Fact] public void Then_TheyAreNotEqual() => Then.Throws();
    }
}