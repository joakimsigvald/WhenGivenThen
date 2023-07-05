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