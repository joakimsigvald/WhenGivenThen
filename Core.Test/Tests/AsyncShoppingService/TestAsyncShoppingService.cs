using Joakimsigvald.WhenGivenThen.Test.Subjects;

namespace Joakimsigvald.WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class TestAsyncShoppingService<TResult>
    : TestSubjectAsync<Subjects.AsyncShoppingService, TResult>
{
    protected override Subjects.AsyncShoppingService CreateSUT()
        => new(The<IOrderService>(), The<IShoppingCartRepository>());
}