using IndependentWork19.DataAccess;

namespace IndependentWork19.Factories;

public class SqlFactory : DataAccessFactory
{
    protected override IDataAccess Create()
    {
        return new SqlDataAccess();
    }
}