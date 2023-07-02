using System;
using System.Threading.Tasks;
using Xunit;
using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public class WhenCreateCart : TestAsyncShoppingService<ShoppingCart>
{
    protected int Id;
    protected override Func<Task<ShoppingCart>> Func => () => SUT.CreateCart(Id);

    public class GivenIdIsOne : WhenCreateCart
    {
        protected override void Given() => Id = 1;
        [Fact] public void ThenCartIdIsOne() => Then.Result.Id.Is(Id);
    }

    public class GivenIdIsTwo : WhenCreateCart
    {
        protected override void Given() => Id = 2;
        [Fact] public void ThenCartIdIsTwo() => Then.Result.Id.Is(Id);
    }
}