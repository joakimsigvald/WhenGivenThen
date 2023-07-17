using Xunit;
using WhenGivenThen.Test.Subjects;
using Moq;

namespace WhenGivenThen.Test.Tests.ShoppingService;

public abstract class WhenPlaceOrder : ShoppingServiceSpec<object>
{
    protected ShoppingCart Cart;

    protected WhenPlaceOrder() => When(() => SUT.PlaceOrder(Cart));

    public class GivenCart : WhenPlaceOrder
    {
        public GivenCart() => Given(() => Cart = new());
        [Fact] public void ThenOrderIsCreated() => Then.The<IOrderService>(_ => _.CreateOrder(Cart));
        [Fact] public void ThenLogOrderCreated() => Then.The<ILogger>(_ => _.Information(It.IsAny<string>()));
    }
}