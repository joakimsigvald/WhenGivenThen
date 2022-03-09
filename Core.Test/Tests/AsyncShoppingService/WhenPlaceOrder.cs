using Applique.WhenGivenThen.Core.Test.Subjects;
using System.Threading.Tasks;
using Xunit;

namespace Applique.WhenGivenThen.Core.Test.Tests.AsyncShoppingService
{
    public class WhenPlaceOrder : TestAsyncShoppingService<object>
    {
        protected ShoppingCart Cart;
        protected override Task ActAsync() => SUT.PlaceOrder(Cart);
        public class GivenCart : WhenPlaceOrder
        {
            [Theory]
            [InlineData(1)]
            [InlineData(2)]
            public void ThenCreateOrderFromCart(int id)
            {
                Cart = new ShoppingCart { Id = id };
                ArrangeAndAct();
                Verify<IOrderService>(s => s.CreateOrder(Cart));
            }
        }
    }
}