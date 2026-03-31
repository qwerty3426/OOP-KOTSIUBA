public class MorningPassStrategy : IGymPassStrategy
{
    public decimal CalculateCost(int hours, bool sauna, bool pool)
    {
        decimal cost = hours * 50m; // ранковий тариф

        if (sauna)
            cost += 100m;

        if (pool)
            cost += 80m;

        return cost;
    }
}
