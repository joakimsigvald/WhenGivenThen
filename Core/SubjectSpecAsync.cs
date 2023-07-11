namespace WhenGivenThen;

public abstract class SubjectSpecAsync<ISUT, TResult> : SpecAsync<TResult>
{
    protected ISUT SUT { get; private set; }
    protected override sealed void Instantiate() => SUT = CreateSUT();
    protected abstract ISUT CreateSUT();
}