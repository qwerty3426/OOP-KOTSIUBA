using IndependentWork24.Core;

namespace IndependentWork24.Decorator;

public class LoggingDecorator : TaskDecorator
{
    public LoggingDecorator(ITask task) : base(task) { }

    public override int Execute()
    {
        Console.WriteLine($"[LOG] Start {GetName()}");
        var result = base.Execute();
        Console.WriteLine($"[LOG] End {GetName()}");
        return result;
    }
}