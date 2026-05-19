using System.Collections.Generic;

namespace IndependentWork22.Components;

public class ProjectTask : IComponent
{
    private List<IComponent> tasks = new();

    public string Title { get; set; }

    public ProjectTask(string title)
    {
        Title = title;
    }

    public void Add(IComponent component)
    {
        tasks.Add(component);
    }

    public void Remove(IComponent component)
    {
        tasks.Remove(component);
    }

    public void Display(int indent)
    {
        Console.WriteLine(
            new string(' ', indent) +
            $"[Проєкт] {Title}");

        foreach (var task in tasks)
        {
            task.Display(indent + 4);
        }
    }
}
