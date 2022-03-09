using Applique.WhenGivenThen.Core.Test.Subjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Applique.WhenGivenThen.Core.Test.Tests.AsyncShoppingService
{
    public class WhenAddItem : TestAsyncShoppingService<ShoppingCart>
    {
        protected int CartId = 123;
        protected ShoppingCartItem[] CartItems;
        protected readonly ShoppingCartItem Item = new ShoppingCartItem();
        public WhenAddItem() => ArrangeAndAct();
        protected override Task ActAsync() => CollectResult(() => SUT.AddToCartCart(CartId, Item));
        protected override void Setup()
            => Mocked<IShoppingCartRepository>()
                .Setup(repo => repo.GetCart(CartId))
                .ReturnsAsync(new ShoppingCart { Id = CartId, Items = CartItems });

        public class GivenEmptyCart : WhenAddItem
        {
            protected override void Given() => CartItems = Array.Empty<ShoppingCartItem>();
            [Fact] public void ThenCartContainOneItem() => Assert.Single(Result.Items);
            [Fact] public void ThenCartIdIsPreserved() => Assert.Equal(CartId, Result.Id);
            [Fact]
            public void ThenStoreUpdatedCart()
                => Verify<IShoppingCartRepository>(repo => repo.StoreCart(Result));
        }

        public class GivenCartWithOneItem : WhenAddItem
        {
            protected override void Given() => CartItems = new[] { new ShoppingCartItem() };
            [Fact] public void ThenCartContainTwoItems() => Assert.Equal(2, Result.Items.Length);
            [Fact] public void ThenItemIsAddedLast() => Assert.Same(Item, Result.Items.Last());
        }
    }
}