using IndependentWork22.Components;

namespace IndependentWork22.Decorators;

public class PriorityDecorator : TaskDecorator
{
    public PriorityDecorator(IComponent component)
        : base(component)
    {
    }

    public override void Display(int indent)
    {
        Console.Write(
            new string(' ', indent) +
            "[HIGH PRIORITY] ");

        component.Display(0);
    }
}
