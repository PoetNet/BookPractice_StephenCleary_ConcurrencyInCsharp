using System.Drawing.Drawing2D;

namespace Examples;

public class ParallelForeEach
{
    void RotateMatrices(IEnumerable<Matrix> matrices, float degrees)
    {
        Parallel.ForEach(matrices, matrix => matrix.Rotate(degrees));
    }
}
