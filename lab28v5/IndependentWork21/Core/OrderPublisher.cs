namespace IndependentWork21.Core;

public class OrderPublisher
{
    public event Action<string>? OrderProcessed;

    public void Publish(string order)
    {
        OrderProcessed?.Invoke(order);
    }
}