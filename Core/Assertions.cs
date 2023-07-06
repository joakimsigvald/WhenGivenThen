using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WhenGivenThen;

public static class Assertions
{
    public static void Is<TValue>(this TValue actual, TValue expected) where TValue : struct 
        => Assert.Equal(expected, actual);
    public static void IsNot<TValue>(this TValue actual, TValue expected) where TValue : struct
        => Assert.NotEqual(expected, actual);
    public static void Is(this object actual, object expected) => Assert.Same(expected, actual);
    public static void IsNot(this object actual, object expected) => Assert.NotSame(expected, actual);
    public static void IsLike(this object actual, object expected) => Assert.Equal(expected, actual);
    public static void IsNotLike(this object actual, object expected) => Assert.NotEqual(expected, actual);
    public static void IsEmpty<TItem>(this IEnumerable<TItem> actual) => Assert.Empty(actual);
    public static void IsNotEmpty<TItem>(this IEnumerable<TItem> actual) => Assert.NotEmpty(actual);
    public static void HasOne<TItem>(this IEnumerable<TItem> actual, Action<TItem> assert = null)
    {
        var val = Assert.Single(actual);
        if (assert is null)
            return;
        assert(val);
    }

    public static void HasCount<TItem>(this IEnumerable<TItem> actual, int expected) => actual.Count().Is(expected);
    public static void Each<TItem>(this IEnumerable<TItem> actual, Func<TItem, bool> predicate)
        => actual.ToList().ForEach(item => Assert.True(predicate(item)));
    public static void Each<TResult>(this IEnumerable<TResult> actual, Func<TResult, int, bool> predicate)
        => actual.Select((it, i) => (it, i)).Each(t => predicate(t.it, t.i));
}