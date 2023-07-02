using System;
using System.Threading.Tasks;

namespace WhenGivenThen;

/// <summary>
/// Not intended for override. Override either TestStatic or TestSubject instead
/// </summary>
public abstract class TestBase<TResult> : Mocking, IDisposable
{
    private Exception _error;
    private TResult _result;
    private TestResult<TResult> _then;

    internal protected TestBase() { }

    public abstract void Dispose();

    protected TResult Result => Then.Result;
    protected TestResult<TResult> Then => _then ??= CreateTestResult();

    protected virtual void Given() { }
    protected virtual void Setup() { }
    protected internal abstract void Instantiate();
    protected abstract void Act();

    protected internal void Execute(Action action, Func<TResult> func)
    {
        if (action is null)
        {
            CollectResult(func ?? throw new NoTestMethod());
            return;
        }
        if (func is not null)
            throw new MoreThanOneTestMethod();
        CatchError(action);
    }

    protected internal Task Execute(Func<Task> action, Func<Task<TResult>> func)
    {
        if (action is null)
            CollectResult(func ?? throw new NoTestMethod());
        else if (func is null)
            CatchError(action);
        else throw new MoreThanOneTestMethod();
        return Task.CompletedTask;
    }

    private TestResult<TResult> CreateTestResult()
    {
        Given();
        Setup();
        Instantiate();
        Act();
        return new(_result, _error, this);
    }

    private void CollectResult(Func<Task<TResult>> act) => CollectResult(() => AsyncHelper.Execute(act));

    private void CollectResult(Func<TResult> act) => CatchError(() => _result = act());

    private void CatchError(Func<Task> act) => CatchError(() => AsyncHelper.Execute(act));

    private void CatchError(Action act)
    {
        try
        {
            act();
        }
        catch (Exception ex)
        {
            _error = ex;
        }
    }
}