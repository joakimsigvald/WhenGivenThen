using Applique.GivenWhenThen.Core.Test.Subjects;
using System.Threading.Tasks;
using Xunit;

namespace Applique.GivenWhenThen.Core.Test.Tests.AsyncShoppingService
{
    public class WhenCreateCart : TestAsyncShoppingService<ShoppingCart>
    {
        protected int Id;
        protected override Task ActAsync() => CollectResult(() => SUT.CreateCart(Id));

        public class GivenIdIsOne : WhenCreateCart
        {
            protected override void Given() => Id = 1;
            public GivenIdIsOne() => ArrangeAndAct();
            [Fact] public void ThenCartIdIsOne() => Assert.Equal(Id, Result.Id);
        }

        public class GivenIdIsTwo : WhenCreateCart
        {
            protected override void Given() => Id = 2;
            public GivenIdIsTwo() => ArrangeAndAct();
            [Fact] public void ThenCartIdIsTwo() => Assert.Equal(Id, Result.Id);
        }
    }
}