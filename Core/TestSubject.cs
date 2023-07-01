namespace Applique.WhenGivenThen;

public abstract class TestSubject<ISUT, TResult> : TestSync<TResult>
{
    protected ISUT SUT { get; private set; }
    protected override sealed void Arrange()
    {
        base.Arrange();
        SUT = CreateSUT();
    }
    protected abstract ISUT CreateSUT();
}