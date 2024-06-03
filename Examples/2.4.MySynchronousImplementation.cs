namespace Examples;

interface IMySuccessAsyncInterface
{
    Task<int> GetValueAsync();
    Task DoSomethingAsync();
    Task DoSomethingAsyncWithCare();
}

interface IMyUnSuccessAsyncInterface
{
    Task<T> NotImplementedAsync<T>();
    Task<int> GetValueAsync(CancellationToken cancellationToken);
}

public class MySynchronousImplementation : IMySuccessAsyncInterface, IMyUnSuccessAsyncInterface
{
    private readonly Task<int> zeroTask = Task.FromResult(0);

    // Задача, завершенная с NotImplementedException
    public Task<int> GetValueAsync()
    {
        return zeroTask;
    }

    // Для методов без возвращаемого значения используются Task.CompletedTask
    public Task DoSomethingAsync()
    {
        return Task.CompletedTask;
    }

    public Task<T> NotImplementedAsync<T>()
    {
        return Task.FromException<T>(new NotImplementedException());
    }

    public Task<int> GetValueAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<int>(cancellationToken);
        }

        return Task.FromResult(13);
    }

    public Task DoSomethingAsyncWithCare()
    {
        try
        {
            DoSomethingSynchronously();
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    private void DoSomethingSynchronously()
    {
        throw new NotImplementedException();
    }
}
