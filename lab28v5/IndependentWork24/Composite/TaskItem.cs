using IndependentWork24.Core;

namespace IndependentWork24.Composite;

public class TaskItem : ITask
{
    private readonly string _name;
    private readonly int _work;

    public TaskItem(string name, int work)
    {
        _name = name;
        _work = work;
    }

    public string GetName() => _name;

    public int Execute()
    {
        Thread.Sleep(_work);
        return _work;
    }
}