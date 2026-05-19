using IndependentWork24.Composite;
using IndependentWork24.Decorator;
using IndependentWork24.Proxy;
using IndependentWork24.Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== LAB 24 ===\n");

        // ======================
        // BASE TASKS
        // ======================
        var t1 = new TaskItem("Task A", 200);
        var t2 = new TaskItem("Task B", 300);

        // ======================
        // COMPOSITE
        // ======================
        var project = new ProjectTask("Project 1");
        project.Add(t1);
        project.Add(t2);

        // ======================
        // DECORATOR
        // ======================
        ITask decorated =
            new LoggingDecorator(
                new PriorityDecorator(project));

        // ======================
        // PROXY
        // ======================
        ITask proxy = new TaskProxy(decorated);

        // ======================
        // RUN
        // ======================
        Console.WriteLine($"Result: {proxy.Execute()}");
        Console.WriteLine($"Second run (cache): {proxy.Execute()}");
    }
}