namespace Joakimsigvald.WhenGivenThen;

public abstract class TestStaticAsync<TResult> : TestAsync<TResult>
{
    protected internal override sealed void Instantiate() { }
}