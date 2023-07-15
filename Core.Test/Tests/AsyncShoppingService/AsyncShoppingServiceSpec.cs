using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class AsyncShoppingServiceSpec<TResult>
    : SubjectSpecAsync<Subjects.ShoppingServiceAsync, TResult>
{
    protected override Subjects.ShoppingServiceAsync CreateSUT()
        => new(The<IOrderService>(), The<IShoppingCartRepository>());
}