using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть тип абонемента (Morning / Day / Full / Night):");
        string passType = Console.ReadLine()!; // ! → гарантовано не null

        Console.WriteLine("Введіть кількість годин:");
        int hours = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Сауна? (true / false):");
        bool sauna = bool.Parse(Console.ReadLine()!);

        Console.WriteLine("Басейн? (true / false):");
        bool pool = bool.Parse(Console.ReadLine()!);

        try
        {
            // Створюємо стратегію через фабрику
            IGymPassStrategy strategy = GymPassStrategyFactory.CreateStrategy(passType);

            // Використовуємо сервіс для розрахунку
            GymService service = new GymService();
            decimal cost = service.CalculatePassCost(hours, sauna, pool, strategy);

            Console.WriteLine($"Вартість абонемента: {cost} грн");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}

