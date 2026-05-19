namespace IndependentWork20.Observers;

public class InventoryUpdateObserver
{
    public void OnOrderProcessed(string order)
    {
        Console.WriteLine($"[STORAGE] Склад оновлено для: {order}");
    }
}