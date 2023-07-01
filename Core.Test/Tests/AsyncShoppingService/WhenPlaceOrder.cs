using Applique.WhenGivenThen.Core.Test.Subjects;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Applique.WhenGivenThen.Core.Test.Tests.AsyncShoppingService;

public class WhenPlaceOrder : TestAsyncShoppingService<object>
{
    protected ShoppingCart Cart;
    protected override Func<Task> Action => () => SUT.PlaceOrder(Cart);
    public class GivenOpenCart : WhenPlaceOrder
    {
        protected override void Given() => Cart = new() { IsOpen = true };
        [Fact] public void ThenCreateOrderFromCart() => Verify<IOrderService>(s => s.CreateOrder(Cart));
    }
    public class GivenClosedCart : WhenPlaceOrder
    {
        protected override void Given() => Cart = new() { IsOpen = false };
        [Fact] public void ThenThrowNotPurcheable() => Assert.IsType<NotPurcheable>(Error);
    }
}