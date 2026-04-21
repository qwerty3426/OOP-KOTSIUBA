public static class GymPassStrategyFactory
{
    public static IGymPassStrategy CreateStrategy(string passType)
    {
        return passType switch
        {
            "Morning" => new MorningPassStrategy(),
            "Day" => new DayPassStrategy(),
            "Full" => new FullPassStrategy(),
            "Night" => new NightPassStrategy(), // 4-та стратегія, ще не зробили
            _ => throw new ArgumentException("Невідомий тип абонемента")
        };
    }
}
