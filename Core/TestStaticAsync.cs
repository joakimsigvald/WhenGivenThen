using System.Threading.Tasks;

namespace Applique.GivenWhenThen.Core
{
    public abstract class TestStaticAsync<TResult> : TestStatic<TResult>
    {
        protected override sealed void Act() => ActAsync().GetAwaiter().GetResult();
        protected abstract Task ActAsync();
    }
}