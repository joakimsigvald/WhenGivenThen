using Applique.WhenGivenThen.Core.Test.Subjects;

namespace Applique.WhenGivenThen.Core.Test.Tests.ShoppingService;

public abstract class TestShoppingService<TResult> : TestSubject<Subjects.ShoppingService, TResult>
{
    protected override Subjects.ShoppingService CreateSUT() => new(MockOf<IOrderService>());
    public TestShoppingService() => ArrangeAndAct();
}