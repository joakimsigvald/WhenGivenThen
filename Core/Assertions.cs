using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WhenGivenThen;

public static class Assertions
{
    public static void Is<TValue>(this TValue actual, TValue expected) => Assert.Equal(expected, actual);
    public static void IsNotNull(this object actual) => Assert.NotNull(actual);
    public static void IsNull(this object actual) => Assert.Null(actual);
    public static void IsSameAs(this object actual, object expected) => Assert.Same(expected, actual);
    public static void IsEmpty<TItem>(this IEnumerable<TItem> actual) => Assert.Empty(actual);
    public static void IsNotEmpty<TItem>(this IEnumerable<TItem> actual) => Assert.Empty(actual);
    public static void IsOne<TItem>(this IEnumerable<TItem> actual) => Assert.Single(actual);
    public static void IsOne<TItem>(this IEnumerable<TItem> actual, Action<TItem> assert) 
        => assert(Assert.Single(actual));

    public static void Counts<TItem>(this IEnumerable<TItem> actual, int expected) => actual.Count().Is(expected);
    public static void IsLast<TItem>(this IEnumerable<TItem> actual, TItem item) => actual.Last().IsSameAs(item);
    public static void Each<TItem>(this IEnumerable<TItem> actual, Action<TItem> assert)
        => actual.ToList().ForEach(assert);
    public static void Each<TResult>(this IEnumerable<TResult> actual, Action<TResult, int> assert)
        => actual.Select((it, i) => (it, i)).ToList().ForEach(t => assert(t.it, t.i));
}