using Applique.WhenGivenThen.Test.Subjects;

namespace Applique.WhenGivenThen.Test.Tests.ShoppingService;

public abstract class TestShoppingService<TResult> : TestSubject<Subjects.ShoppingService, TResult>
{
    protected override Subjects.ShoppingService CreateSUT() => new(MockOf<IOrderService>());
    public TestShoppingService() => ArrangeAndAct();
}