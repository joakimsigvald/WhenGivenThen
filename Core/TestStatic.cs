namespace WhenGivenThen;

public abstract class TestStatic<TResult> : TestSync<TResult>
{
    protected override sealed void Instantiate() { }
}