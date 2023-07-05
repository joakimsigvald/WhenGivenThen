using System;

namespace WhenGivenThen;

public interface ITestPipeline<TResult>
{
    ITestPipeline<TResult> Given(params Action[] arrangements);
    TestResult<TResult> Then { get; }
}