namespace IndependentWork20.Observers;

public class OrderConfirmationEmailObserver
{
    public void OnOrderProcessed(string order)
    {
        Console.WriteLine($"[EMAIL] Підтвердження замовлення: {order}");
    }
}