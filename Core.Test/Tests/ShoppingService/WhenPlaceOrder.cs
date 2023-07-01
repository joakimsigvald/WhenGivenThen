using Applique.WhenGivenThen.Test.Subjects;
using System;
using Xunit;

namespace Applique.WhenGivenThen.Test.Tests.ShoppingService;

public class WhenPlaceOrder : TestShoppingService<object>
{
    protected ShoppingCart Cart;
    protected override Action Action => () => SUT.PlaceOrder(Cart);
    public class GivenCart : WhenPlaceOrder
    {
        protected override void Given() => Cart = new();
        [Fact] public void ThenCreateOrderFromCart() => Verify<IOrderService>(s => s.CreateOrder(Cart));
    }
}