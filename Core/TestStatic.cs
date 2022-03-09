namespace Applique.GivenWhenThen.Core
{
    public abstract class TestStatic<TResult> : TestBase<TResult>
    {
        protected override sealed void Arrange() => base.Arrange();
    }
}