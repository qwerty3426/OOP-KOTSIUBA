using IndependentWork24.Core;

namespace IndependentWork24.Composite;

public class ProjectTask : ITask
{
    private readonly string _name;
    private readonly List<ITask> _tasks = new();

    public ProjectTask(string name)
    {
        _name = name;
    }

    public void Add(ITask task) => _tasks.Add(task);

    public string GetName() => _name;

    public int Execute()
    {
        int total = 0;

        foreach (var task in _tasks)
            total += task.Execute();

        return total;
    }
}