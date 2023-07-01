using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace Joakimsigvald.WhenGivenThen;

public class TestResult<TResult>
{
    private readonly Mocking _mocking;

    public TestResult(TResult result, Exception error, Mocking mocking)
    {
        Result = result;
        Error = error;
        _mocking = mocking;
    }

    public TResult Result { get; }
    public Exception Error { get; }
    public void Throws<TError>() => Assert.IsType<TError>(Error);

    public void The<TObject>() where TObject : class
        => Mocked<TObject>().Verify();

    public void The<TObject>(Expression<Action<TObject>> expression) where TObject : class
        => Mocked<TObject>().Verify(expression);

    public void The<TObject>(Expression<Action<TObject>> expression, Times times) where TObject : class
        => Mocked<TObject>().Verify(expression, times);

    public void The<TObject>(Expression<Action<TObject>> expression, Func<Times> times) where TObject : class
        => Mocked<TObject>().Verify(expression, times);

    public void The<TObject, TReturns>(Expression<Func<TObject, TReturns>> expression) where TObject : class
        => Mocked<TObject>().Verify(expression);

    public void The<TObject, TReturns>(Expression<Func<TObject, TReturns>> expression, Times times)
        where TObject : class
        => Mocked<TObject>().Verify(expression, times);

    public void The<TObject, TReturns>(Expression<Func<TObject, TReturns>> expression, Func<Times> times)
        where TObject : class
        => Mocked<TObject>().Verify(expression, times);

    private Mock<TObject> Mocked<TObject>() where TObject : class
        => _mocking.Mocked<TObject, TObject>(_ => _);
}