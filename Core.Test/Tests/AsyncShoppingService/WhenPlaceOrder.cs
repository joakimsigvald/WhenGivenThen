using System;
using System.Threading.Tasks;
using Xunit;
using Joakimsigvald.WhenGivenThen.Test.Subjects;

namespace Joakimsigvald.WhenGivenThen.Test.Tests.AsyncShoppingService;

public class WhenPlaceOrder : TestAsyncShoppingService<object>
{
    protected ShoppingCart Cart;
    protected override Func<Task> Action => () => SUT.PlaceOrder(Cart);
    public class GivenOpenCart : WhenPlaceOrder
    {
        protected override void Given() => Cart = new() { IsOpen = true };
        [Fact] public void ThenOrderIsCreated() => Then.The<IOrderService>(_ => _.CreateOrder(Cart));
    }
    public class GivenClosedCart : WhenPlaceOrder
    {
        protected override void Given() => Cart = new() { IsOpen = false };
        [Fact] public void ThenThrowsNotPurcheable() => Then.Throws<NotPurcheable>();
    }
}