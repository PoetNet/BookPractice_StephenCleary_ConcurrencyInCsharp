namespace Examples;

public class ReactionToProcess
{
    async Task MyMethodAsync(IProgress<double>? progress = null)
    {
        bool done = false;
        double percentComplete = 0;
        while (!done)
        {
            // ...
            progress?.Report(percentComplete);
        }
    }

    async Task CallMyMethodAsync()
    {
        var progress = new Progress<double>();
        progress.ProgressChanged += (sender, args) =>
        {
            // ...
        };

        await MyMethodAsync(progress);
    }
}
