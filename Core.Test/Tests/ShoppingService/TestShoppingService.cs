using WhenGivenThen.Test.Subjects;

namespace WhenGivenThen.Test.Tests.ShoppingService;

public abstract class TestShoppingService<TResult> : TestSubject<Subjects.ShoppingService, TResult>
{
    protected override Subjects.ShoppingService CreateSUT() => new(The<IOrderService>());
}