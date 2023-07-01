namespace Applique.WhenGivenThen;

public abstract class TestStaticAsync<TResult> : TestAsync<TResult>
{
    protected override sealed void Arrange() => base.Arrange();
}