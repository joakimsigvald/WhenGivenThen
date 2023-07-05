using System;
using System.Collections.Generic;
using System.Linq;

namespace WhenGivenThen;

/// <summary>
/// Not intended for override. Override one of TestStatic, TestSubject, TestStaticAsync or TestSubjectAsync instead
/// </summary>
public abstract class TestBase<TResult> : Mocking, ITestPipeline<TResult>, IDisposable
{
    private readonly Stack<Action> _arrangements = new();
    private Action _command;
    private Func<TResult> _function;
    private Exception _error;
    private TResult _result;
    private TestResult<TResult> _then;

    public ITestPipeline<TResult> Given(params Action[] arrangements)
    {
        if (_then != null)
            throw new InvalidOperationException("Given must be called before Then");
        foreach (var arrange in arrangements.Reverse())
            _arrangements.Push(arrange);
        return this;
    }

    public TestResult<TResult> Then => _then ??= CreateTestResult();

    public abstract void Dispose();

    protected TResult Result => Then.Result;

    protected ITestPipeline<TResult> When(Action act)
        => When(act ?? throw new InvalidOperationException("Act cannot be null"), null);

    protected ITestPipeline<TResult> When(Func<TResult> act)
        => When(null, act ?? throw new InvalidOperationException("Act cannot be null"));

    protected ITestPipeline<TResult> When(Action command, Func<TResult> function)
    {
        if (_command != null || _function != null)
            throw new InvalidOperationException("When may only be called once");
        if (_arrangements.Any())
            throw new InvalidOperationException("When must be called before Given");
        if (_then != null)
            throw new InvalidOperationException("When must be called before Then");
        (_command, _function) = (command, function); return this;
    }

    protected internal abstract void Instantiate();

    private TestResult<TResult> CreateTestResult()
    {
        foreach (var arr in _arrangements) arr();
        Instantiate();
        CatchError(_command ?? GetResult);
        return new(_result, _error, this);
    }

    private void GetResult() => _result = _function();

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