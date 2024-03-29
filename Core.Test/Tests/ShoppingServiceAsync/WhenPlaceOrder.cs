﻿using Xunit;
using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class WhenPlaceOrder : ShoppingServiceAsyncSpec<object>
{
    protected ShoppingCart Cart;

    protected WhenPlaceOrder() => When(() => SUT.PlaceOrder(Cart));

    public class GivenOpenCart : WhenPlaceOrder
    {
        public GivenOpenCart() => Given(() => Cart = new() { IsOpen = true });
        [Fact] public void ThenOrderIsCreated() => Then.Does<IOrderService>(_ => _.CreateOrder(Cart));
    }

    public class GivenClosedCart : WhenPlaceOrder
    {
        public GivenClosedCart() => Given(() => Cart = new() { IsOpen = false });
        [Fact] public void ThenThrowsNotPurcheable() => Then.Throws<NotPurcheable>();
    }
}