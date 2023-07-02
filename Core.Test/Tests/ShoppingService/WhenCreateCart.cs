using System;
using Xunit;
using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.ShoppingService;

public class WhenCreateCart : TestShoppingService<ShoppingCart>
{
    protected int Id;
    protected override Func<ShoppingCart> Func => () => SUT.CreateCart(Id);

    public class GivenIdIsOne : WhenCreateCart
    {
        protected override void Given() => Id = 1;
        [Fact] public void ThenCartIdIsOne() => Then.Result.Id.Is(1);
    }

    public class GivenIdIsTwo : WhenCreateCart
    {
        protected override void Given() => Id = 2;
        [Fact] public void ThenCartIdIsTwo() => Then.Result.Id.Is(2);
    }
}