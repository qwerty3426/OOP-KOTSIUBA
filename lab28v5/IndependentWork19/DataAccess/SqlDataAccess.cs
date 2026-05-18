namespace IndependentWork19.DataAccess;

public class SqlDataAccess : IDataAccess
{
    public void GetData()
    {
        Console.WriteLine("[SQL] Отримання даних з SQL бази");
    }
}