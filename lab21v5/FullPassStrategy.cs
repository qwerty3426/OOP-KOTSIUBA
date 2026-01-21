public class FullPassStrategy : IGymPassStrategy
{
    public decimal CalculateCost(int hours, bool sauna, bool pool)
    {
        decimal cost = hours * 90m; // повний доступ

        if (sauna)
            cost += 150m;

        if (pool)
            cost += 120m;

        return cost;
    }
}
