using System.Diagnostics;

namespace Examples;

public class AggregateExceptionHandling
{
    void SomeMethods(double[] array)
    {
        try
        {
            Parallel.Invoke(
                () => { throw new Exception(); },
                () => { throw new Exception(); }
           );
        }
        catch (AggregateException ex)
        {
            ex.Handle(exception =>
            {
                Trace.WriteLine(exception);
                return true; // "handled"
            });
        }
    }

}