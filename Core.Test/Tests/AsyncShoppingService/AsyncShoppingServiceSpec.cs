using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class AsyncShoppingServiceSpec<TResult>
    : SubjectSpecAsync<Subjects.AsyncShoppingService, TResult>
{
    protected override Subjects.AsyncShoppingService CreateSUT()
        => new(The<IOrderService>(), The<IShoppingCartRepository>());
}