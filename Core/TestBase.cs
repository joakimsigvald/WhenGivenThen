using System;
using System.Threading.Tasks;

namespace WhenGivenThen;

/// <summary>
/// Not intended for override. Override either TestStatic or TestSubject instead
/// </summary>
public abstract class TestBase<TResult> : Mocking, IDisposable
{
    private bool _isArranged;
    private bool _isActed;
    private Exception _error;
    private TResult _result;
    private TestResult<TResult> _then;

    internal protected TestBase() { }

    public abstract void Dispose();

    protected void ArrangeAndAct()
    {
        Arrange();
        Act();
    }

    protected void Arrange()
    {
        if (_isArranged) return;
        Given();
        Setup();
        Instantiate();
        _isArranged = true;
    }

    protected void Act()
    {
        if (_isActed) return;
        if (!_isArranged) throw new InvalidOperationException("Must arrange before act");
        DoAct();
        _isActed = true;
    }

    protected TResult Result => Then.Result;
    protected TestResult<TResult> Then => _then ??= CreateTestResult();

    protected virtual void Given() { }
    protected virtual void Setup() { }
    protected internal abstract void Instantiate();

    protected abstract void DoAct();

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
            return CollectResult(func ?? throw new NoTestMethod());
        if (func is not null)
            throw new MoreThanOneTestMethod();
        return CatchError(action);
    }

    private TestResult<TResult> CreateTestResult()
    {
        ArrangeAndAct();
        return new(_result, _error, this);
    }

    private void CollectResult(Func<TResult> act)
    {
        try
        {
            _result = act();
        }
        catch (Exception ex)
        {
            _error = ex;
        }
    }

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

    private Task CollectResult(Func<Task<TResult>> act)
    {
        try
        {
            _result = AsyncHelper.Execute(act);
        }
        catch (Exception ex)
        {
            _error = ex;
        }
        return Task.CompletedTask;
    }

    private Task CatchError(Func<Task> act)
    {
        try
        {
            AsyncHelper.Execute(act);
        }
        catch (Exception ex)
        {
            _error = ex;
        }
        return Task.CompletedTask;
    }
}