namespace IndependentWork21.Observers;

public class InventoryUpdateObserver
{
    public void OnOrderProcessed(string order)
    {
        Console.WriteLine($"[STORAGE] {order}");
    }
}