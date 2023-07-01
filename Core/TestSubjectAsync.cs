namespace Joakimsigvald.WhenGivenThen;

public abstract class TestSubjectAsync<ISUT, TResult> : TestAsync<TResult>
{
    protected ISUT SUT { get; private set; }
    protected internal override sealed void Instantiate() => SUT = CreateSUT();
    protected abstract ISUT CreateSUT();
}