using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class TestAsyncShoppingService<TResult>
    : TestSubjectAsync<Subjects.AsyncShoppingService, TResult>
{
    protected override Subjects.AsyncShoppingService CreateSUT()
        => new(The<IOrderService>(), The<IShoppingCartRepository>());
}