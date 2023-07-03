using System;

namespace WhenGivenThen.Test.Assertions;

public abstract class TestAssertions<TResult> : TestStatic<TResult>
{
}

public abstract class WhenIs : TestStatic<object>
{
    protected int Actual;
    protected int Expected;

    protected override Action Action => () => Actual.Is(Expected);

    public class Given_Actual_And_Expected_Is_1 : WhenIs
    {
    }
}
