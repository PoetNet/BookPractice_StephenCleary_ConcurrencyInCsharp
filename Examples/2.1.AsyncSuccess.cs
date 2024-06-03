namespace Examples;

public class AsyncSuccess
{
    async Task<T> DelayResult<T>(T result, TimeSpan delay)
    {
        await Task.Delay(delay);
        return result;
    }
}
