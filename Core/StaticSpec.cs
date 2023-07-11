namespace WhenGivenThen;

public abstract class StaticSpec<TResult> : Spec<TResult>
{
    protected override sealed void Instantiate() { }
}