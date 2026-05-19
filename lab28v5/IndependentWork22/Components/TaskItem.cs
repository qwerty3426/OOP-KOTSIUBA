namespace IndependentWork22.Components;

public class TaskItem : IComponent
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title, bool isCompleted)
    {
        Title = title;
        IsCompleted = isCompleted;
    }

    public virtual void Display(int indent)
    {
        string status = IsCompleted ? "[Виконано]" : "[Не виконано]";

        Console.WriteLine(
            new string(' ', indent) +
            $"- {Title} {status}");
    }
}
