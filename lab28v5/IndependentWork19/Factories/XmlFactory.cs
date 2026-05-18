using IndependentWork19.DataAccess;

namespace IndependentWork19.Factories;

public class XmlFactory : DataAccessFactory
{
    protected override IDataAccess Create()
    {
        return new XmlDataAccess();
    }
}