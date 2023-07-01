﻿using System;
using Xunit;
using Joakimsigvald.WhenGivenThen.Test.Subjects;

namespace Joakimsigvald.WhenGivenThen.Test.Tests.ShoppingService;

public class WhenPlaceOrder : TestShoppingService<object>
{
    protected ShoppingCart Cart;
    protected override Action Action => () => SUT.PlaceOrder(Cart);
    public class GivenCart : WhenPlaceOrder
    {
        protected override void Given() => Cart = new();
        [Fact] public void ThenOrderIsCreated() => Then.The<IOrderService>(_ => _.CreateOrder(Cart));
    }
}