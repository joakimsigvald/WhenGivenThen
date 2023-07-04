using System;

namespace WhenGivenThen;

/// <summary>
/// Not intended for override. Override either TestStatic or TestSubject instead
/// </summary>
public abstract class TestBase<TResult> : Mocking, IDisposable
{
    private Action _action = null;
    private Func<TResult> _func = null;
    private Exception _error;
    private TResult _result;
    private TestResult<TResult> _then;

    protected void When(Action action)
    {
        AssertNoTestMethod();
        _action = action;
    }

    protected void When(Func<TResult> func)
    {
        AssertNoTestMethod();
        _func = func;
    }

    private void AssertNoTestMethod()
    {
        if (_action != null || _func != null)
            throw new MoreThanOneTestMethod();
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