public class NightPassStrategy : IGymPassStrategy
{
    public decimal CalculateCost(int hours, bool sauna, bool pool)
    {
        decimal cost = hours * 60m; // нічний тариф, трохи дешевше за денний
        if (sauna)
            cost += 90m; // сауна
        if (pool)
            cost += 70m; // басейн
        cost += 50m; // фіксована нічна націнка
        return cost;
    }
}
