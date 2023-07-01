namespace Applique.WhenGivenThen.Core;

public abstract class TestSubjectAsync<ISUT, TResult> : TestAsync<TResult>
{
    protected ISUT SUT { get; private set; }
    protected override sealed void Arrange()
    {
        base.Arrange();
        SUT = CreateSUT();
    }
    protected abstract ISUT CreateSUT();
}