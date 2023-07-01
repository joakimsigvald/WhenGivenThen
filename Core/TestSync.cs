using System;

namespace Joakimsigvald.WhenGivenThen;

/// <summary>
/// Not intended for override. Override either TestStatic or TestSubject instead
/// </summary>
public abstract class TestSync<TResult> : TestBase<TResult>
{
    protected virtual Action Action => null;
    protected virtual Func<TResult> Func => null;
    protected override sealed void DoAct() => Execute(Action, Func);

    public override void Dispose()
    {
        TearDown();
    }

    protected virtual void TearDown() { }
}