namespace WhenGivenThen;

public abstract class TestStatic<TResult> : TestSync<TResult>
{
    protected internal override sealed void Instantiate() { }
}