namespace IndependentWork20.Strategies;

public class ProcessCashOrderStrategy : IOrderStrategy
{
    public void Process(string order)
    {
        Console.WriteLine($"[CASH] Обробка готівкового замовлення: {order}");
    }
}