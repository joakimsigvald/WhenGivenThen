using System.Threading.Tasks;
using Moq.Language.Flow;

namespace Applique.WhenGivenThen.Core;

public static class SetupExtensions
{
    public static IReturnsResult<TSubject> ReturnsAsync<TSubject, TReturnValue>(
        this ISetup<TSubject, Task<TReturnValue>> setup, TReturnValue returnValue)
        where TSubject : class => setup.Returns(Task.FromResult(returnValue));
}