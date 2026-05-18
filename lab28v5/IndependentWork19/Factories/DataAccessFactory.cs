using IndependentWork19.DataAccess;

namespace IndependentWork19.Factories;

public abstract class DataAccessFactory
{
    protected abstract IDataAccess Create();

    public void GetData()
    {
        var dao = Create();
        dao.GetData();
    }
}