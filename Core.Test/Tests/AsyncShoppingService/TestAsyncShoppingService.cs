using Applique.WhenGivenThen.Test.Subjects;

namespace Applique.WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class TestAsyncShoppingService<TResult>
    : TestSubjectAsync<Subjects.AsyncShoppingService, TResult>
{
    protected override Subjects.AsyncShoppingService CreateSUT()
        => new(MockOf<IOrderService>(), MockOf<IShoppingCartRepository>());

    public TestAsyncShoppingService() => ArrangeAndAct();
}