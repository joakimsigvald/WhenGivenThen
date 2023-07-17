using WhenGivenThen.Fixture;

namespace WhenGivenThen.Test.Tests.AsyncShoppingService;

public abstract class ShoppingServiceAsyncSpec<TResult>
    : SubjectSpecAsync<Subjects.ShoppingServiceAsync, TResult>
{
}