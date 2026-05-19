using IndependentWork22.Components;

namespace IndependentWork22.Decorators;

public abstract class TaskDecorator : IComponent
{
    protected IComponent component;

    public TaskDecorator(IComponent component)
    {
        this.component = component;
    }

    public virtual void Display(int indent)
    {
        component.Display(indent);
    }
}
