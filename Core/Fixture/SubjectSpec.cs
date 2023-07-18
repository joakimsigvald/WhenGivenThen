namespace WhenGivenThen.Fixture;

public abstract class SubjectSpec<ISUT, TResult> : Spec<TResult> where ISUT : class
{
    protected ISUT SUT { get; private set; }
    protected override sealed void Instantiate() => SUT = Mocker.CreateInstance<ISUT>();
    protected override sealed void ProvideDefaultsForTuples()
    {
        //TODO
        //Use(("Missing", "Missing"));
        //var type = typeof(ISUT);
        //var ctors = type.GetConstructors();
        //foreach (var ctor in ctors)
        //{
        //    var args = ctor.GetParameters();
        //    foreach (var arg in args)
        //    {
        //        if (typeof(System.Runtime.CompilerServices.ITuple).IsAssignableFrom(arg.ParameterType))
        //            Use(("", ""));
        //        //Use(Mocker.Get(arg.ParameterType));
        //    }
        //}
    }
}