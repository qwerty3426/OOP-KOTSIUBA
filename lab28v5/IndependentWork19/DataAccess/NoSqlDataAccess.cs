namespace IndependentWork19.DataAccess;

public class NoSqlDataAccess : IDataAccess
{
    public void GetData()
    {
        Console.WriteLine("[NoSQL] Отримання даних з NoSQL бази");
    }
}