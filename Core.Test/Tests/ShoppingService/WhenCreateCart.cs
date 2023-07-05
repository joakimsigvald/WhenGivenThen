using Xunit;
using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.ShoppingService;

public abstract class WhenCreateCart : TestShoppingService<ShoppingCart>
{
    protected int Id;

    protected WhenCreateCart() => When(() => SUT.CreateCart(Id));

    public class GivenIdIsOne : WhenCreateCart
    {
        public GivenIdIsOne() => Given(() => Id = 1);
        [Fact] public void ThenCartIdIsOne() => Then.Result.Id.Is(1);
        [Fact] public void ThenCartIdIsNotTwo() => Then.Result.Id.IsNot(2);
    }

    public class GivenIdIsTwo : WhenCreateCart
    {
        public GivenIdIsTwo() => Given(() => Id = 2);
        [Fact] public void ThenCartIdIsTwo() => Then.Result.Id.Is(2);
    }
}