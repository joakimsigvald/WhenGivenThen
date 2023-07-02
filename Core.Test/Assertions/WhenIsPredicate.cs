using System;
using WhenGivenThen.Test.Subjects;
using Xunit;

namespace WhenGivenThen.Test.Assertions;

public class WhenIsPredicate : TestStatic<object>
{
    protected ShoppingCart Cart;
    protected Order Order;

    protected override Action Action => () => Cart.Satisfies(IsBasisOf, Order);
    private static bool IsBasisOf(ShoppingCart c, Order o) => c.Id == o.Id;

    public class GivenPredicateIsTrue : WhenIsPredicate
    {
        protected override void Given()
        {
            Cart = new() { Id = 2 };
            Order = new() { Id = Cart.Id };
        }
        [Fact] public void ThenPass() => Then.Error.IsNull();
    }

    public class GivenPredicateIsFalse : WhenIsPredicate
    {
        protected override void Given()
        {
            Cart = new() { Id = 2 };
            Order = new() { Id = Cart.Id + 1 };
        }
        [Fact] public void ThenFail() => Then.Throws<Xunit.Sdk.TrueException>();
    }
}