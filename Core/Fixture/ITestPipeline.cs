using System;
using WhenGivenThen.Verification;

namespace WhenGivenThen.Fixture;

public interface ITestPipeline<TResult>
{
    ITestPipeline<TResult> Given(params Action[] arrangements);
    TestResult<TResult> Then { get; }
}