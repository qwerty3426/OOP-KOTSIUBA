namespace IndependentWork21.Observers;

public class OrderConfirmationEmailObserver
{
    public void OnOrderProcessed(string order)
    {
        Console.WriteLine($"[EMAIL] {order}");
    }
}