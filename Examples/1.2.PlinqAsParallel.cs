namespace Examples;

public class PlinqAsParallel
{
    IEnumerable<bool> PrimalityTest(IEnumerable<int> values)
    {
        return values.AsParallel().Select(x => IsPrime(x));
    }

    private bool IsPrime(int x)
    {
        throw new NotImplementedException();
    }
}
