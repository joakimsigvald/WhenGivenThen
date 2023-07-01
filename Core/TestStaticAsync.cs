namespace Applique.WhenGivenThen.Core;

public abstract class TestStaticAsync<TResult> : TestAsync<TResult>
{
    protected override sealed void Arrange() => base.Arrange();
}