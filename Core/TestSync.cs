namespace WhenGivenThen;

/// <summary>
/// Not intended for direct override. Override either TestStatic or TestSubject instead
/// </summary>
public abstract class TestSync<TResult> : TestBase<TResult>
{
    public override sealed void Dispose() => TearDown();
    protected virtual void TearDown() { }
}