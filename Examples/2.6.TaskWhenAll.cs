namespace Examples;

public class TaskWhenAll
{
    async Task MyMethodAsync()
    {
        Task<int> task1 = Task.FromResult(3); 
        Task<int> task2 = Task.FromResult(5); 
        Task<int> task3 = Task.FromResult(7);

        await Task.WhenAll(task1, task2, task3);
    }
}
