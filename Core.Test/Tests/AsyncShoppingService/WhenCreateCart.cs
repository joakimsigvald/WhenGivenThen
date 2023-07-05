﻿using Xunit;
using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class WhenCreateCart : TestAsyncShoppingService<ShoppingCart>
{
    protected int Id;

    protected WhenCreateCart() => When(() => SUT.CreateCart(Id));

    public class GivenIdIsOne : WhenCreateCart
    {
        public GivenIdIsOne() => Given(() => Id = 1);
        [Fact] public void ThenCartIdIsOne() => Then.Result.Id.Is(Id);
    }

    public class GivenIdIsTwo : WhenCreateCart
    {
        public GivenIdIsTwo() => Given(() => Id = 2);
        [Fact] public void ThenCartIdIsTwo() => Then.Result.Id.Is(Id);
    }
}