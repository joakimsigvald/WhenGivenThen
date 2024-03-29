﻿using System.Threading.Tasks;
using Moq.Language.Flow;

namespace WhenGivenThen.Fixture;

public static class Extensions
{
    public static IReturnsResult<TSubject> ReturnsAsync<TSubject, TReturnValue>(
    this ISetup<TSubject, Task<TReturnValue>> setup, TReturnValue returnValue)
    where TSubject : class => setup.Returns(Task.FromResult(returnValue));
}