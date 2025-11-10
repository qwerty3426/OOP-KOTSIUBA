using System;
using System.Collections.Generic;
using System.Linq;

// ======== Власний виняток ========
class InvalidRatingException : Exception
{
    public InvalidRatingException(double value)
        : base($"Помилка: недопустима оцінка {value}. Діапазон [0;10].") { }
}

// ======== Моделі ========
class Rating
{
    public int UserId { get; }
    public double Score { get; }

    public Rating(int userId, double score)
    {
        if (score < 0 || score > 10)
            throw new InvalidRatingException(score);
        UserId = userId;
        Score = score;
    }
}

class Movie
{
    public string Title { get; }
    public List<Rating> Ratings { get; } = new();

    public Movie(string title) => Title = title;

    public void AddRating(Rating r) => Ratings.Add(r);

    public double Середнє() => Ratings.Average(r => r.Score);

    public double? ВідсіченеСереднє()
    {
        if (Ratings.Count < 5) return Середнє();
        var list = Ratings.Select(r => r.Score).OrderBy(x => x).ToList();
        return list.Skip(1).Take(list.Count - 2).Average();
    }
}

// ======== Узагальнений репозиторій ========
class Repository<T>
{
    private List<T> items = new();
    public void Add(T item) => items.Add(item);
    public IEnumerable<T> All() => items;
    public IEnumerable<T> Where(Func<T, bool> f) => items.Where(f);
}

// ======== Генеричний метод ========
static class Utils
{
    public static T MaxBy<T>(IEnumerable<T> src, Func<T, double> key)
    {
        return src.OrderByDescending(key).First();
    }
}

// ======== Основна програма ========
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Лабораторна №5 — Варіант 5: Рейтинги фільмів\n");

        var repo = new Repository<Movie>();
        var m1 = new Movie("Неонові сни");
        var m2 = new Movie("Тихі відлуння");
        repo.Add(m1); repo.Add(m2);

        try
        {
            m1.AddRating(new Rating(1, 9));
            m1.AddRating(new Rating(2, 8));
            m1.AddRating(new Rating(3, 10));
            m1.AddRating(new Rating(4, 7));
            m1.AddRating(new Rating(5, 6));

            m2.AddRating(new Rating(6, 5));
            m2.AddRating(new Rating(7, 6));
            m2.AddRating(new Rating(8, 7));

            // Спроба некоректної оцінки
            m2.AddRating(new Rating(9, 15));
        }
        catch (InvalidRatingException ex)
        {
            Console.WriteLine($"[Виняток] {ex.Message}\n");
        }

        // Вивід статистики
        foreach (var m in repo.All())
        {
            Console.WriteLine($"Фільм: {m.Title}");
            Console.WriteLine($"  Кількість оцінок: {m.Ratings.Count}");
            Console.WriteLine($"  Середня оцінка: {m.Середнє():0.00}");
            Console.WriteLine($"  Відсічене середнє: {m.ВідсіченеСереднє():0.00}\n");
        }

        // LINQ + Generics
        var найкращий = Utils.MaxBy(repo.All(), x => x.Середнє());
        Console.WriteLine($"Найкращий фільм: {найкращий.Title} із середнім {найкращий.Середнє():0.00}");
    }
}
