using System.Threading.Tasks;

namespace Applique.WhenGivenThen.Core
{
    public abstract class TestSubjectAsync<ISUT, TResult> : TestSubject<ISUT, TResult>
    {
        protected override sealed void Act() => ActAsync().GetAwaiter().GetResult();
        protected abstract Task ActAsync();
    }
}