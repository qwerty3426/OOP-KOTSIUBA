using IndependentWork24.Core;

namespace IndependentWork24.Decorator;

public abstract class TaskDecorator : ITask
{
    protected ITask _task;

    protected TaskDecorator(ITask task)
    {
        _task = task;
    }

    public virtual string GetName() => _task.GetName();

    public virtual int Execute() => _task.Execute();
}