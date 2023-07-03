using System;
using System.Threading.Tasks;
using Xunit;
using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public class WhenRemoveItem : TestAsyncShoppingService<ShoppingCart>
{
    protected int CartId = 123;
    protected ShoppingCartItem[] CartItems;
    protected readonly ShoppingCartItem Item = new("X");
    private ShoppingCart _cart;
    protected ShoppingCart Cart => _cart ??= CreateCart();
    ShoppingCart CreateCart() => new() { Id = CartId, Items = CartItems };

protected override Func<Task<ShoppingCart>> Func => () => SUT.RemoveFromCart(CartId, Cart.Items[0]);

    protected override void Setup()
        => Mocked<IShoppingCartRepository>()
            .Setup(repo => repo.GetCart(CartId))
            .ReturnsAsync(new ShoppingCart { Id = CartId, Items = CartItems });

    public class GivenCartWithOneItem : WhenRemoveItem
    {
        protected override void Given() => CartItems = new[] { new ShoppingCartItem("X") };
        [Fact] public void ThenCartIsEmpty() => Then.Result.Items.IsEmpty();
    }
}