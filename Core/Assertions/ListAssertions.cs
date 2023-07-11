using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WhenGivenThen.Assertions;

public static class ListAssertions
{
    /// <summary>
    /// Assert.Empty
    /// </summary>
    public static void IsEmpty<TItem>(this IEnumerable<TItem> actual)
        => Assert.Empty(actual);

    /// <summary>
    /// Assert.NotEmpty
    /// </summary>
    public static void IsNotEmpty<TItem>(this IEnumerable<TItem> actual)
        => Assert.NotEmpty(actual);

    /// <summary>
    /// Assert.Single
    /// </summary>
    public static void HasOne<TItem>(this IEnumerable<TItem> actual) => Assert.Single(actual);

    /// <summary>
    /// actual.HasOne(it => predicate(it).IsTrue());
    /// </summary>
    public static void HasOne<TItem>(this IEnumerable<TItem> actual, Func<TItem, bool> predicate)
        => actual.HasOne(it => predicate(it).IsTrue());

    /// <summary>
    /// assertion(Assert.Single(actual));
    /// </summary>
    public static void HasOne<TItem>(this IEnumerable<TItem> actual, Action<TItem> assertion) 
        => assertion(Assert.Single(actual));

    /// <summary>
    /// actual.Count().Is(expected)
    /// </summary>
    public static void HasCount<TItem>(this IEnumerable<TItem> actual, int expected)
        => actual.Count().Is(expected);

    /// <summary>
    /// actual.Each(it => predicate(it).IsTrue());
    /// </summary>
    public static void Each<TItem>(this IEnumerable<TItem> actual, Func<TItem, bool> predicate)
        => actual.Each(it => predicate(it).IsTrue());

    /// <summary>
    /// actual.ToList().ForEach(item => assertion(item));
    /// </summary>
    public static void Each<TItem>(this IEnumerable<TItem> actual, Action<TItem> assertion)
        => actual.ToList().ForEach(item => assertion(item));

    /// <summary>
    /// actual.Each((it, i) => predicate(it, i).IsTrue());
    /// </summary>
    public static void Each<TResult>(this IEnumerable<TResult> actual, Func<TResult, int, bool> predicate)
        => actual.Each((it, i) => predicate(it, i).IsTrue());

    /// <summary>
    /// actual.Select((it, i) => (it, i)).Each(t => assertion(t.it, t.i));
    /// </summary>
    public static void Each<TResult>(this IEnumerable<TResult> actual, Action<TResult, int> assertion)
        => actual.Select((it, i) => (it, i)).Each(t => assertion(t.it, t.i));
}