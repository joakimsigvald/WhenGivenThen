using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WhenGivenThen;

public static class Assertions 
{
    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void Is(this decimal actual, decimal expected, int precision)
        => Assert.Equal(expected, actual, precision);

    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void Is(this double actual, double expected, int precision)
        => Assert.Equal(expected, actual, precision);

    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void Is(this DateTime actual, DateTime expected, TimeSpan precision)
        => Assert.Equal(expected, actual, precision);

    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void Is(this double actual, double expected, double tolerance)
        => Assert.Equal(expected, actual, tolerance);

    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void Is(this float actual, float expected, double tolerance)
        => Assert.Equal(expected, actual, tolerance);

    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void Is(this string actual, 
        string expected, bool ignoreCase, bool ignoreLineEndingDifferences, bool ignoreWhiteSpaceDifferences)
        => Assert.Equal(expected, actual, ignoreCase, ignoreLineEndingDifferences, ignoreWhiteSpaceDifferences);

    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void Is(this double actual, double expected, int precision, MidpointRounding rounding)
        => Assert.Equal(expected, actual, precision, rounding);

    /// <summary>
    /// Xunit.Assert.NotEqual
    /// </summary>
    public static void IsNot<TValue>(this TValue actual, TValue expected) where TValue : struct
        => Assert.NotEqual(expected, actual);

    /// <summary>
    /// Xunit.Assert.Same
    /// </summary>
    public static void Is(this object actual, object expected)
        => Assert.Same(expected, actual);

    /// <summary>
    /// Xunit.Assert.NotSame
    /// </summary>
    public static void IsNot(this object actual, object expected)
        => Assert.NotSame(expected, actual);

    /// <summary>
    /// Xunit.Assert.Equal
    /// </summary>
    public static void IsEqualTo(this object actual, object expected)
        => Assert.Equal(expected, actual);

    /// <summary>
    /// Xunit.Assert.NotEqual
    /// </summary>
    public static void IsNotEqualTo(this object actual, object expected)
        => Assert.NotEqual(expected, actual);

    /// <summary>
    /// Xunit.Assert.Equivalent
    /// </summary>
    public static void IsLike(this object actual, object expected) 
        => Assert.Equivalent(expected, actual);

    /// <summary>
    /// Xunit.Assert.Empty
    /// </summary>
    public static void IsEmpty<TItem>(this IEnumerable<TItem> actual) 
        => Assert.Empty(actual);

    /// <summary>
    /// Xunit.Assert.NotEmpty
    /// </summary>
    public static void IsNotEmpty<TItem>(this IEnumerable<TItem> actual) 
        => Assert.NotEmpty(actual);

    /// <summary>
    /// Xunit.Assert.Single with Assert.True of predicate on item
    /// </summary>
    public static void HasOne<TItem>(this IEnumerable<TItem> actual, Func<TItem, bool> predicate
        = null)
    {
        var val = Assert.Single(actual);
        if (predicate is null)
            return;
        Assert.True(predicate(val));
    }

    /// <summary>
    /// actual.Count().Is(expected)
    /// </summary>
    public static void HasCount<TItem>(this IEnumerable<TItem> actual, int expected) 
        => actual.Count().Is(expected);

    /// <summary>
    /// actual.ToList().ForEach(item => Assert.True(predicate(item)))
    /// </summary>
    public static void Each<TItem>(this IEnumerable<TItem> actual, Func<TItem, bool> predicate)
        => actual.ToList().ForEach(item => Assert.True(predicate(item)));

    /// <summary>
    /// actual.Select((it, i) => (it, i)).Each(t => predicate(t.it, t.i))
    /// </summary>
    public static void Each<TResult>(this IEnumerable<TResult> actual, Func<TResult, int, bool> predicate)
        => actual.Select((it, i) => (it, i)).Each(t => predicate(t.it, t.i));
}