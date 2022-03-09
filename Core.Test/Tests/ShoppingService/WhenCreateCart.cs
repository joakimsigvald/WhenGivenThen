using Applique.GivenWhenThen.Core.Test.Subjects;
using Xunit;

namespace Applique.GivenWhenThen.Core.Test.Tests.ShoppingService
{
    public class WhenCreateCart : TestShoppingService<ShoppingCart>
    {
        protected int Id;
        protected override void Act() => CollectResult(() => SUT.CreateCart(Id));
        public WhenCreateCart() => ArrangeAndAct();

        public class GivenIdIsOne : WhenCreateCart
        {
            protected override void Given() => Id = 1;
            [Fact] public void ThenCartIdIsOne() => Assert.Equal(1, Result.Id);
        }

        public class GivenIdIsTwo : WhenCreateCart
        {
            protected override void Given() => Id = 2;
            [Fact] public void ThenCartIdIsTwo() => Assert.Equal(2, Result.Id);
        }
    }
}