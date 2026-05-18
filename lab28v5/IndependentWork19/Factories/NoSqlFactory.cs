using IndependentWork19.DataAccess;

namespace IndependentWork19.Factories;

public class NoSqlFactory : DataAccessFactory
{
    protected override IDataAccess Create()
    {
        return new NoSqlDataAccess();
    }
}