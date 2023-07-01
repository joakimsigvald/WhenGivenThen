using System.Threading;
using System;
using System.Threading.Tasks;

namespace Joakimsigvald.WhenGivenThen;

public static class AsyncHelper
{
    private static readonly TaskFactory _taskFactory = new
        (CancellationToken.None,
        TaskCreationOptions.None,
        TaskContinuationOptions.None,
        TaskScheduler.Default);

    public static void Execute(Func<Task> action)
        => _taskFactory.StartNew(action).Unwrap().GetAwaiter().GetResult();

    public static TResult Execute<TResult>(Func<Task<TResult>> func)
        => _taskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
}