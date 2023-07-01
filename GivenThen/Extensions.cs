using Xunit;

namespace GivenThen;

public static class Extensions
{
    public static void Is(this int actual, int expected) => Assert.Equal(expected, actual);
    public static void IsSameAs(this object actual, object expected) => Assert.Same(expected, actual);
    public static void IsOne<TResult>(this TResult[] actual) => Assert.Single(actual);
    public static void Is<T>(this object value) => Assert.IsType<T>(value);
}