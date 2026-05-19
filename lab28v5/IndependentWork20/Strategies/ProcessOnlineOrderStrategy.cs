namespace IndependentWork20.Strategies;

public class ProcessOnlineOrderStrategy : IOrderStrategy
{
    public void Process(string order)
    {
        Console.WriteLine($"[ONLINE] Обробка онлайн замовлення: {order}");
    }
}