using Xunit;

namespace WhenGivenThen.Assertions;

public static class ObjectAssertions
{
    /// <summary>
    /// Assert.Same
    /// </summary>
    public static void Is(this object actual, object expected)
        => Assert.Same(expected, actual);

    /// <summary>
    /// Assert.NotSame
    /// </summary>
    public static void IsNot(this object actual, object expected)
        => Assert.NotSame(expected, actual);

    /// <summary>
    /// Assert.Equal
    /// </summary>
    public static void IsEqualTo(this object actual, object expected)
        => Assert.Equal(expected, actual);

    /// <summary>
    /// Assert.NotEqual
    /// </summary>
    public static void IsNotEqualTo(this object actual, object expected)
        => Assert.NotEqual(expected, actual);

    /// <summary>
    /// Assert.Equivalent
    /// </summary>
    public static void IsLike(this object actual, object expected)
        => Assert.Equivalent(expected, actual);
}