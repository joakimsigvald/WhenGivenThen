using Xunit;
using WhenGivenThen.Test.Subjects;
using Moq;

namespace WhenGivenThen.Test.Tests.ShoppingService;

public abstract class WhenPlaceOrder : ShoppingServiceSpec<object>
{
    protected ShoppingCart Cart;

    protected WhenPlaceOrder() => When(() => SUT.PlaceOrder(Cart));

    public abstract class GivenCart : WhenPlaceOrder
    {
        protected GivenCart() => Given(() => Cart = new());
        [Fact] public void ThenOrderIsCreated() => Then.The<IOrderService>(_ => _.CreateOrder(Cart));
    }

    public class AndShopName : GivenCart
    {
        private const string _shopName = "BookShop";

        public AndShopName() => Use((_shopName, ""));

        [Fact]
        public void ThenLogOrderCreatedWithShopName()
            => Then.The<ILogger>(_ => _.Information(It.Is<string>(s => s.Contains(_shopName))));
    }

    public class AndShopNameAndDivision : GivenCart
    {
        private const string _shopName = "BookShop";
        private const string _division = "Fiction";

        public AndShopNameAndDivision() => Use((_shopName, _division));

        [Fact]
        public void ThenLogOrderCreatedWithDivision()
            => Then.The<ILogger>(_ => _.Information(It.Is<string>(s => s.Contains(_division))));
    }
}