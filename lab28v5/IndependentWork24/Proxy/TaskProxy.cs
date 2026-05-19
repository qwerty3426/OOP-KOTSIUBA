using IndependentWork24.Core;

namespace IndependentWork24.Proxy;

public class TaskProxy : ITask
{
    private readonly ITask _real;

    private static readonly Dictionary<string, int> Cache = new();

    public TaskProxy(ITask real)
    {
        _real = real;
    }

    public string GetName() => _real.GetName();

    public int Execute()
    {
        if (Cache.ContainsKey(GetName()))
        {
            Console.WriteLine("⚡ CACHE HIT");
            return Cache[GetName()];
        }

        Console.WriteLine("⚙️ EXECUTE REAL TASK");

        int result = _real.Execute();

        Cache[GetName()] = result;

        return result;
    }
}