using System;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private readonly Func<T, T, TR> _operation;
    private readonly T _operand1;
    private readonly T _operand2;

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        _operation = operation;
        _operand1 = operand1;
        _operand2 = operand2;
    }

    public TR Result { get; private set; }

    public void StartEvaluation()
    {
        Task.Run(() => Evaluate());
    }

    public void Evaluate()
    {
        Result = _operation(_operand1, _operand2);
    }
}

class Program
{
    private static void Main()
    {
        Func<int, int, int> operation = (a, b) => a + b;
        ParallelUtils<int, int> parallelUtils = new ParallelUtils<int, int>(operation, 10, 20);
        parallelUtils.StartEvaluation();
        parallelUtils.Evaluate();
        Console.WriteLine($"Result: {parallelUtils.Result}");
    }
}
