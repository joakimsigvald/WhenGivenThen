using System;
using WhenGivenThen.Verification;

namespace WhenGivenThen.Fixture;

public interface ITestPipeline<TResult>
{
    ITestPipeline<TResult> Given(params Action[] arrangements);
    ITestPipeline<TResult> Use<TValue>(TValue value);
    TestResult<TResult> Then { get; }
}