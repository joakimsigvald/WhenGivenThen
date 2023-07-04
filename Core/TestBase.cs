using System;

namespace WhenGivenThen;

/// <summary>
/// Not intended for override. Override either TestStatic or TestSubject instead
/// </summary>
public abstract class TestBase<TResult> : Mocking, IDisposable
{
    private Action _action;
    private Func<TResult> _func;
    private Exception _error;
    private TResult _result;
    private TestResult<TResult> _then;

    protected TestBase<TResult> When(Action action) => When(action, null);

    protected TestBase<TResult> When(Func<TResult> func) => When(null, func);

    private TestBase<TResult> When(Action action, Func<TResult> func)
    {
        (_action, _func) = _action is null && _func is null ? (action, func) : throw new MoreThanOneTestMethod();
        return this;
    }

    public abstract void Dispose();

    protected TResult Result => Then.Result;
    protected TestResult<TResult> Then => _then ??= CreateTestResult();

    protected virtual void Given() { }
    protected virtual void Setup() { }
    protected internal abstract void Instantiate();

    private TestResult<TResult> CreateTestResult()
    {
        Given();
        Setup();
        Instantiate();
        Act();
        return new(_result, _error, this);
    }

    private void Act()
    {
        if (_action is null)
            CollectResult(_func ?? throw new NoTestMethod());
        else
            CatchError(_action);
    }

    private void CollectResult(Func<TResult> act) => CatchError(() => _result = act());

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