namespace WhenGivenThen;

public abstract class TestSubjectAsync<ISUT, TResult> : TestAsync<TResult>
{
    protected ISUT SUT { get; private set; }
    protected override sealed void Instantiate() => SUT = CreateSUT();
    protected abstract ISUT CreateSUT();
}