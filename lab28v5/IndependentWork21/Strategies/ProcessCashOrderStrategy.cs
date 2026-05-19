namespace IndependentWork21.Strategies;

public class ProcessCashOrderStrategy : IOrderStrategy
{
    public void Process(string order)
    {
        Console.WriteLine($"[CASH] {order}");
    }
}