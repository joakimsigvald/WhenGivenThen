using Applique.WhenGivenThen.Core.Test.Subjects;
using Xunit;

namespace Applique.WhenGivenThen.Core.Test.Tests.ShoppingService
{
    public class WhenPlaceOrder : TestShoppingService<object>
    {
        protected ShoppingCart Cart;
        protected override void Act() => SUT.PlaceOrder(Cart);
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