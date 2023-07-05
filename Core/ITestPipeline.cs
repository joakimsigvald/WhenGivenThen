using System;

namespace WhenGivenThen;

public interface ITestPipeline<TResult>
{
    ITestPipeline<TResult> Given(Action arrange);
    TestResult<TResult> Then { get; }
}