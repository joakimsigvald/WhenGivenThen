using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Joakimsigvald.WhenGivenThen.Test.Subjects;

namespace Joakimsigvald.WhenGivenThen.Test.Tests.AsyncShoppingService;

public class WhenAddItem : TestAsyncShoppingService<ShoppingCart>
{
    protected int CartId = 123;
    protected ShoppingCartItem[] CartItems;
    protected readonly ShoppingCartItem NewItem = new();

    protected override Func<Task<ShoppingCart>> Func => () => SUT.AddToCartCart(CartId, NewItem);

    protected override void Setup()
        => Mocked<IShoppingCartRepository>()
            .Setup(repo => repo.GetCart(CartId))
            .ReturnsAsync(new ShoppingCart { Id = CartId, Items = CartItems });

    public class GivenEmptyCart : WhenAddItem
    {
        protected override void Given() => CartItems = Array.Empty<ShoppingCartItem>();
        [Fact] public void ThenCartHasOneItem() => Then.Result.Items.IsOne();
        [Fact] public void TheIdIsPreserved() => Then.Result.Id.Is(CartId);
        [Fact] public void ThenCartIsStored() => Then.The<IShoppingCartRepository>(_ => _.StoreCart(Result));
    }

    public class GivenCartWithOneItem : WhenAddItem
    {
        protected override void Given() => CartItems = new[] { new ShoppingCartItem() };
        [Fact] public void ThenCartHasTwoItems() => Then.Result.Items.Length.Is(2);
        [Fact] public void ThenNewItemIsLast() => Then.Result.Items.Last().IsSameAs(NewItem);
    }
}