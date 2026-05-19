namespace IndependentWork21.Strategies;

public class ProcessOnlineOrderStrategy : IOrderStrategy
{
    public void Process(string order)
    {
        Console.WriteLine($"[ONLINE] {order}");
    }
}