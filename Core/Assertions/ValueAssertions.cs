using System;
using Xunit;

namespace WhenGivenThen.Assertions;

public static class ValueAssertions
{
    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is<TValue>(this TValue actual, TValue expected) where TValue : struct
        => Assert.Equal(expected, actual);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is(this decimal actual, decimal expected, int precision)
        => Assert.Equal(expected, actual, precision);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is(this double actual, double expected, int precision)
        => Assert.Equal(expected, actual, precision);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is(this DateTime actual, DateTime expected, TimeSpan precision)
        => Assert.Equal(expected, actual, precision);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is(this double actual, double expected, double tolerance)
        => Assert.Equal(expected, actual, tolerance);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is(this float actual, float expected, double tolerance)
        => Assert.Equal(expected, actual, tolerance);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is(this string actual,
        string expected, bool ignoreCase, bool ignoreLineEndingDifferences, bool ignoreWhiteSpaceDifferences)
        => Assert.Equal(expected, actual, ignoreCase, ignoreLineEndingDifferences, ignoreWhiteSpaceDifferences);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void Is(this double actual, double expected, int precision, MidpointRounding rounding)
        => Assert.Equal(expected, actual, precision, rounding);

    /// <summary>
    /// Assert.NotEqual
    /// </summary>
    public static void IsNot<TValue>(this TValue actual, TValue expected) where TValue : struct
        => Assert.NotEqual(expected, actual);

    /// <summary>
    /// Assert.True
    /// </summary>
    public static void IsTrue(this bool actual) => Assert.True(actual);

    /// <summary>
    /// Assert.False
    /// </summary>
    public static void IsFalse(this bool actual) => Assert.False(actual);
}