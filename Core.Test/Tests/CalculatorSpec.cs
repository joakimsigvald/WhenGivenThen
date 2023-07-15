﻿using WhenGivenThen.Assertions;
using WhenGivenThen.Test.Subjects;
using Xunit;

namespace WhenGivenThen.Test.Tests;

public class CalculatorSpec : StaticSpec<int>
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(3, 4, 7)]
    public void WhenAdd_ThenReturnSum(int x, int y, int sum)
    => When(() => Calculator.Add(x, y)).Then.Result.Is(sum);

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 4, 12)]
    public void WhenMultiply_ThenReturnProduct(int x, int y, int product)
        => When(() => Calculator.Multiply(x, y)).Then.Result.Is(product);
}

public abstract class WhenAdd : StaticSpec<int>
{
    protected int X;
    protected int Y;
    public WhenAdd() => When(() => Calculator.Add(X, Y));

    public class Given_1_1 : WhenAdd
    {
        public Given_1_1() => (X, Y) = (1, 1);
        [Fact] public void Then_Return_2() => Result.Is(2);
        [Fact] public void Then_Return_Between_1_And_3() => Result.IsGreaterThan(1).And.BeLessThan(3);
    }

    public class Given_2_3 : WhenAdd
    {
        public Given_2_3() => (X, Y) = (2, 3);
        [Fact] public void Then_Return_5() => Result.Is(5);
    }
}