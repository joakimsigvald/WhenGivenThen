using Applique.GivenWhenThen.Core.Test.Subjects;

namespace Applique.GivenWhenThen.Core.Test.Tests.AsyncShoppingService
{
    public abstract class TestAsyncShoppingService<TResult>
        : TestSubjectAsync<Subjects.AsyncShoppingService, TResult>
    {
        protected override Subjects.AsyncShoppingService CreateSUT()
            => new Subjects.AsyncShoppingService(
                MockOf<IOrderService>(),
                MockOf<IShoppingCartRepository>());
    }
}