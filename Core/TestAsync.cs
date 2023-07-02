using System;
using System.Threading.Tasks;

namespace WhenGivenThen;

/// <summary>
/// Not intended for override. Override either TestStaticAsync or TestSubjectAsync instead
/// </summary>
public abstract class TestAsync<TResult> : TestBase<TResult>
{
    internal protected TestAsync() { }
    protected override sealed void Act() => AsyncHelper.Execute(ActAsync);
    protected virtual Func<Task> Action => null;
    protected virtual Func<Task<TResult>> Func => null;
    protected Task ActAsync() => Execute(Action, Func);
    public override void Dispose() => AsyncHelper.Execute(TearDown);
    protected virtual Task TearDown() => Task.CompletedTask;
}