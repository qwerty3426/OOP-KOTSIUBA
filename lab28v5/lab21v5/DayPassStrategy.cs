public class DayPassStrategy : IGymPassStrategy
{
    public decimal CalculateCost(int hours, bool sauna, bool pool)
    {
        decimal cost = hours * 70m; // денний тариф

        if (sauna)
            cost += 120m;

        if (pool)
            cost += 100m;

        return cost;
    }
}
