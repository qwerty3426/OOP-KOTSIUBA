public class TransactionLogger : ITransactionLogger
{
    public void Log(decimal amount)
    {
        Console.WriteLine($"Лог: Платіж на {amount} грн виконано.");
    }
}
