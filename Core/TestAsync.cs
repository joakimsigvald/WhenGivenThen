using System;
using System.Threading.Tasks;

namespace WhenGivenThen;

/// <summary>
/// Not intended for override. Override either TestStaticAsync or TestSubjectAsync instead
/// </summary>
public abstract class TestAsync<TResult> : TestBase<TResult>
{
    protected void When(Func<Task> action) => When(() => AsyncHelper.Execute(action));
    protected void When(Func<Task<TResult>> func) => When(() => AsyncHelper.Execute(func));
    public override sealed void Dispose() => AsyncHelper.Execute(TearDown);
    protected virtual Task TearDown() => Task.CompletedTask;
}