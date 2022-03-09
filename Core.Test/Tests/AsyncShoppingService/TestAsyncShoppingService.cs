using Applique.WhenGivenThen.Core.Test.Subjects;

namespace Applique.WhenGivenThen.Core.Test.Tests.AsyncShoppingService
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