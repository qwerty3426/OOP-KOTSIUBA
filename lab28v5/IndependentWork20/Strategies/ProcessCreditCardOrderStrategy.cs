namespace IndependentWork20.Strategies;

public class ProcessCreditCardOrderStrategy : IOrderStrategy
{
    public void Process(string order)
    {
        Console.WriteLine($"[CARD] Обробка карткового замовлення: {order}");
    }
}