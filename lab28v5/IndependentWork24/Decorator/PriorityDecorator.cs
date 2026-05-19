using IndependentWork24.Core;

namespace IndependentWork24.Decorator;

public class PriorityDecorator : TaskDecorator
{
    public PriorityDecorator(ITask task) : base(task) { }

    public override int Execute()
    {
        Console.WriteLine("🔥 High priority task");
        return base.Execute();
    }
}