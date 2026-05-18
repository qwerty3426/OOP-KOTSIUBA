using IndependentWork19.Factories;

namespace IndependentWork19.Core;

public class DataManager
{
    private static DataManager? _instance;
    private static readonly object _lock = new();

    private DataAccessFactory? _factory;

    private DataManager() { }

    public static DataManager Instance
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new DataManager();
                return _instance;
            }
        }
    }

    public void SetFactory(DataAccessFactory factory)
    {
        _factory = factory;
    }

    public void GetData()
    {
        _factory?.GetData();
    }
}