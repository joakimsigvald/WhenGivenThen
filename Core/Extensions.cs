using System.Threading.Tasks;
using Moq.Language.Flow;
using Xunit;

namespace Joakimsigvald.WhenGivenThen;

public static class Extensions
{
    public static void Is(this int actual, int expected) => Assert.Equal(expected, actual);
    public static void IsSameAs(this object actual, object expected) => Assert.Same(expected, actual);
    public static void IsOne<TResult>(this TResult[] actual) => Assert.Single(actual);
    public static IReturnsResult<TSubject> ReturnsAsync<TSubject, TReturnValue>(
    this ISetup<TSubject, Task<TReturnValue>> setup, TReturnValue returnValue)
    where TSubject : class => setup.Returns(Task.FromResult(returnValue));
}