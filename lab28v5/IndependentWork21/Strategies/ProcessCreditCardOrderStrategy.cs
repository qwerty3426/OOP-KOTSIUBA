namespace IndependentWork21.Strategies;

public class ProcessCreditCardOrderStrategy : IOrderStrategy
{
    public void Process(string order)
    {
        Console.WriteLine($"[CARD] {order}");
    }
}