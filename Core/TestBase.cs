using System;
using System.Threading.Tasks;

namespace Applique.GivenWhenThen.Core
{
    /// <summary>
    /// Not intended for override. Override either TestStatic or TestSubject instead
    /// </summary>
    public abstract class TestBase<TResult> : Mocking
    {
        internal protected TestBase() { }
        protected TResult Result { get; private set; }
        protected virtual void Given() { }
        protected virtual void Setup() { }
        protected virtual void Arrange()
        {
            Given();
            Setup();
        }
        protected abstract void Act();
        protected void ArrangeAndAct()
        {
            Arrange();
            Act();
        }
        protected void CollectResult(Func<TResult> act) => Result = act();
        protected Task CollectResult(Func<Task<TResult>> act)
        {
            var task = act();
            CollectResult(() => task.GetAwaiter().GetResult());
            return task;
        }
    }
}