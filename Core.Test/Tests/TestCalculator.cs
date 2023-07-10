using WhenGivenThen.Test.Subjects;
using Xunit;

namespace WhenGivenThen.Test.Tests;

public class TestCalculator : TestStatic<int>
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(3, 4, 7)]
    public void WhenAddThenReturnSum(int x, int y, int sum)
    => When(() => Calculator.Add(x, y)).Then.Result.Is(sum);

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 4, 12)]
    public void WhenMultiplyThenReturnProduct(int x, int y, int product)
        => When(() => Calculator.Multiply(x, y)).Then.Result.Is(product);
}

public abstract class WhenAdd : TestStatic<int>
{
    protected int X;
    protected int Y;
    public WhenAdd() => When(() => Calculator.Add(X, Y));

    public class Given_1_1 : WhenAdd
    {
        public Given_1_1() => (X, Y) = (1, 1);
        [Fact] public void Then_Return_2() => Result.Is(2);
    }

    public class Given_2_3 : WhenAdd
    {
        public Given_2_3() => (X, Y) = (2, 3);
        [Fact] public void Then_Return_5() => Result.Is(5);
    }
}