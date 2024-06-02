namespace Examples;

interface IObserver<in T>
{
    void OnNext(T item);
    void OnCompleted();
    void OnError(Exception error);
}

interface IObservable<in T>
{
    IDisposable Subscribe(IObserver<TResult> observer);
}

public class TResult
{
}