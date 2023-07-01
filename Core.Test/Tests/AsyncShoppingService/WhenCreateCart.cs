using Applique.WhenGivenThen.Core.Test.Subjects;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Applique.WhenGivenThen.Core.Test.Tests.AsyncShoppingService;

public class WhenCreateCart : TestAsyncShoppingService<ShoppingCart>
{
    protected int Id;
    protected override Func<Task<ShoppingCart>> Func => () => SUT.CreateCart(Id);

    public class GivenIdIsOne : WhenCreateCart
    {
        protected override void Given() => Id = 1;
        [Fact] public void ThenCartIdIsOne() => Assert.Equal(Id, Result.Id);
    }

    public class GivenIdIsTwo : WhenCreateCart
    {
        protected override void Given() => Id = 2;
        [Fact] public void ThenCartIdIsTwo() => Assert.Equal(Id, Result.Id);
    }
}