namespace WhenGivenThen;

public abstract class TestStaticAsync<TResult> : TestAsync<TResult>
{
    protected override sealed void Instantiate() { }
}