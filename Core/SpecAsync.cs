using System;
using System.Threading.Tasks;

namespace WhenGivenThen;

/// <summary>
/// Not intended for direct override. Override either TestStaticAsync or TestSubjectAsync instead
/// </summary>
public abstract class SpecAsync<TResult> : SpecBase<TResult>
{
    protected ITestPipeline<TResult> When(Func<Task> action) => When(() => AsyncHelper.Execute(action));
    protected ITestPipeline<TResult> When(Func<Task<TResult>> func) => When(() => AsyncHelper.Execute(func));
    public override sealed void Dispose() => AsyncHelper.Execute(TearDown);
    protected virtual Task TearDown() => Task.CompletedTask;
}