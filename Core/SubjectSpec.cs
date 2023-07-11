namespace WhenGivenThen;

public abstract class SubjectSpec<ISUT, TResult> : Spec<TResult>
{
    protected ISUT SUT { get; private set; }
    protected override sealed void Instantiate() => SUT = CreateSUT();
    protected abstract ISUT CreateSUT();
}