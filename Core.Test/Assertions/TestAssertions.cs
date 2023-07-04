namespace WhenGivenThen.Test.Assertions;

public abstract class WhenIs : TestStatic<object>
{
    protected int Actual;
    protected int Expected;

    protected WhenIs() => When(() => Actual.Is(Expected));

    public class Given_Actual_And_Expected_Is_1 : WhenIs
    {
    }
}