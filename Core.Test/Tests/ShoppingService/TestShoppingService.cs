using Applique.GivenWhenThen.Core.Test.Subjects;

namespace Applique.GivenWhenThen.Core.Test.Tests.ShoppingService
{
    public abstract class TestShoppingService<TResult> : TestSubject<Subjects.ShoppingService, TResult>
    {
        protected override Subjects.ShoppingService CreateSUT()
            => new Subjects.ShoppingService(MockOf<IOrderService>());
    }
}