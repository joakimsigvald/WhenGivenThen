using System;
using System.Linq;
using Xunit;
using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class WhenAddItem : TestAsyncShoppingService<ShoppingCart>
{
    protected int CartId = 123;
    protected ShoppingCartItem[] CartItems;
    protected readonly ShoppingCartItem NewItem = new("N1");

    protected WhenAddItem() => When(() => SUT.AddToCart(CartId, NewItem));

    protected override void Setup()
        => Mocked<IShoppingCartRepository>()
            .Setup(repo => repo.GetCart(CartId))
            .ReturnsAsync(new ShoppingCart { Id = CartId, Items = CartItems });

    public class GivenEmptyCart : WhenAddItem
    {
        protected override void Given() => CartItems = Array.Empty<ShoppingCartItem>();
        [Fact] public void ThenCartIsNotEmpty() => Then.Result.Items.IsNotEmpty();
        [Fact] public void ThenCartHasOneItem() => Then.Result.Items.IsOne();
        [Fact] public void TheIdIsPreserved() => Then.Result.Id.Is(CartId);
        [Fact] public void ThenCartIsStored() => Then.The<IShoppingCartRepository>(_ => _.StoreCart(Result));
    }

    public class GivenCartWithOneItem : WhenAddItem
    {
        protected override void Given() => CartItems = new[] { new ShoppingCartItem("A1") };
        [Fact] public void ThenCartHasTwoItems() => Then.Result.Items.Counts(2);
        [Fact] public void ThenNewItemIsLast() => Then.Result.Items.IsLast(
            Result.Items.Single(it => it.Sku == NewItem.Sku));
        [Fact] public void ThenNewItemIsCloned() => Then.Result.Items.Last().IsNotSameAs(NewItem);
        [Fact] public void ThenItemsAreNotNull() => Then.Result.Items.Each(it => it.IsNot(null));
        [Fact] public void ThenItemsHaveLineNumbers() 
            => Then.Result.Items.Each((it, i) => it.LineNumber.Is(i + 1));
    }
}