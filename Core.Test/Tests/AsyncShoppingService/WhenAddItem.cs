using System;
using System.Linq;
using Xunit;
using WhenGivenThen.Test.Subjects;
using WhenGivenThen.Assertions;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class WhenAddItem : AsyncShoppingServiceSpec<ShoppingCart>
{
    protected int CartId = 123;
    protected ShoppingCartItem[] CartItems;
    protected readonly ShoppingCartItem NewItem = new("N1");

    protected WhenAddItem() => When(() => SUT.AddToCart(CartId, NewItem))
        .Given(
        () => CartItems ??= Array.Empty<ShoppingCartItem>(),
        () => Make<IShoppingCartRepository>()
        .Setup(repo => repo.GetCart(CartId))
        .ReturnsAsync(new ShoppingCart { Id = CartId, Items = CartItems }));

    public class GivenEmptyCart : WhenAddItem
    {
        [Fact] public void ThenCartIsNotEmpty() => Result.Items.IsNotEmpty();
        [Fact] public void ThenCartHasOneItem() => Result.Items.ContainsSingle();
        [Fact] public void TheIdIsPreserved() => Result.Id.Is(CartId);
        [Fact] public void ThenCartIsStored() => Then.The<IShoppingCartRepository>(_ => _.StoreCart(Result));
    }

    public class GivenCartWithOneItem : WhenAddItem
    {
        public GivenCartWithOneItem() => Given(() => CartItems = new[] { new ShoppingCartItem("A1") });
        [Fact] public void ThenCartHasTwoItems() => Result.Items.Length.Is(2);
        [Fact] public void ThenNewItemIsLast() => Result.Items.Last().Sku.Is(NewItem.Sku);
        [Fact] public void ThenNewItemIsCloned() => Result.Items.Last().IsNot(NewItem);
        [Fact] public void ThenItemsAreNotNull() => Result.Items.Each(it => it != null);
        [Fact] public void ThenItemsHaveLineNumbers() => Result.Items.Each((it, i) => it.LineNumber == i + 1);
    }
}