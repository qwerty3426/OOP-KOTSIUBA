public class GymService
{
    public decimal CalculatePassCost(int hours, bool sauna, bool pool, IGymPassStrategy strategy)
    {
        return strategy.CalculateCost(hours, sauna, pool);
    }
}
