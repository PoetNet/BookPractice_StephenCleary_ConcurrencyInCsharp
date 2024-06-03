namespace Examples;

public class StringWithTimeout
{
    // Возвращает null, если служба не вернет ответ в течение 3 секунд:
    async Task<string?> DownloadStringWithTimeout(HttpClient client, string uri)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        Task<string> downloadTask = client.GetStringAsync(uri);
        Task timeoutTask = Task.Delay(Timeout.Infinite, cts.Token);

        Task completedTask = await Task.WhenAny(downloadTask, timeoutTask);
        if (completedTask == timeoutTask)
        {
            return null;
        }

        return await downloadTask;
    }
}
