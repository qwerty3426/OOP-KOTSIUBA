using IndependentWork22.Components;

namespace IndependentWork22.Decorators;

public class DueDateDecorator : TaskDecorator
{
    private string dueDate;

    public DueDateDecorator(
        IComponent component,
        string dueDate)
        : base(component)
    {
        this.dueDate = dueDate;
    }

    public override void Display(int indent)
    {
        component.Display(indent);

        Console.WriteLine(
            new string(' ', indent + 2) +
            $"Термін: {dueDate}");
    }
}
