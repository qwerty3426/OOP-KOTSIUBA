using IndependentWork22.Components;
using IndependentWork22.Decorators;

namespace IndependentWork22;

class Program
{
    static void Main(string[] args)
    {
        TaskItem task1 = new TaskItem("Створити UML", false);
        TaskItem task2 = new TaskItem("Написати код", true);
        TaskItem task3 = new TaskItem("Протестувати програму", false);

        ProjectTask project = new ProjectTask("OOP Project");

        project.Add(task1);
        project.Add(task2);
        project.Add(task3);

        ProjectTask subProject = new ProjectTask("Документація");
        subProject.Add(new TaskItem("README.md", true));
        subProject.Add(new TaskItem("Контрольні питання", false));

        project.Add(subProject);

        IComponent priorityTask =
            new PriorityDecorator(task1);

        IComponent dueDateTask =
            new DueDateDecorator(task2, "25.05.2026");

        Console.WriteLine("=== Звичайний проєкт ===");
        project.Display(0);

        Console.WriteLine("\n=== Декоровані завдання ===");
        priorityTask.Display(0);
        dueDateTask.Display(0);
    }
}