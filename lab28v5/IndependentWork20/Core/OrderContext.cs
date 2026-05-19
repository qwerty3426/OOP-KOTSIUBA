using IndependentWork20.Strategies;

namespace IndependentWork20.Core;

public class OrderContext
{
    private IOrderStrategy _strategy;

    public OrderContext(IOrderStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IOrderStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Execute(string order)
    {
        _strategy.Process(order);
    }
}