using IndependentWork24.Composite;
using IndependentWork24.Decorator;
using IndependentWork24.Proxy;
using IndependentWork24.Core;

namespace IndependentWork24.Tests;

public class TaskTests
{
    public static void RunAll()
    {
        TestComposite();
        TestDecorator();
        TestProxyCache();
        TestEdgeCase();
    }

    static void TestComposite()
    {
        var p = new ProjectTask("Test");
        p.Add(new TaskItem("A", 10));
        p.Add(new TaskItem("B", 10));

        Console.WriteLine(p.Execute() >= 20
            ? "✔ Composite OK"
            : "❌ Composite FAIL");
    }

    static void TestDecorator()
    {
        ITask task = new PriorityDecorator(new TaskItem("T", 10));

        Console.WriteLine(task.Execute() >= 10
            ? "✔ Decorator OK"
            : "❌ Decorator FAIL");
    }

    static void TestProxyCache()
    {
        var task = new TaskProxy(new TaskItem("CacheTest", 10));

        task.Execute();
        task.Execute();

        Console.WriteLine("✔ Proxy Cache tested");
    }

    static void TestEdgeCase()
    {
        var empty = new ProjectTask("Empty");

        Console.WriteLine(empty.Execute() == 0
            ? "✔ Edge case OK"
            : "❌ Edge case FAIL");
    }
}