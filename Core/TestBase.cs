using System;
using System.Threading.Tasks;

namespace Applique.WhenGivenThen.Core;

/// <summary>
/// Not intended for override. Override either TestStatic or TestSubject instead
/// </summary>
public abstract class TestBase<TResult> : Mocking, IDisposable
{
    internal protected TestBase() { }
    protected Exception Error { get; set; }
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

    private void CollectResult(Func<TResult> act)
    {
        try
        {
            Result = act();
        }
        catch (Exception ex)
        {
            Error = ex;
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
            Error = ex;
        }
    }

    private Task CollectResult(Func<Task<TResult>> act)
    {
        try
        {
            Result = AsyncHelper.Execute(act);
        }
        catch (Exception ex)
        {
            Error = ex;
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
            Error = ex;
        }
        return Task.CompletedTask;
    }

    public abstract void Dispose();
}