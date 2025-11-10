# Lab5 - Variant 5: Movie Ratings

**Мета:** показати роботу узагальнених типів, колекцій, LINQ і обробки винятків у домені "фільми/рейтинги".

Є дві сутності:
- `Movie` — фільм, який має назву, рік та список оцінок.
- `Rating` — оцінка користувача (0–10).

Агрегація: `Movie` містить колекцію `List<Rating>`.

- Узагальнений репозиторій `Repository<T>` з методами: `Add`, `Remove`, `Find`, `All`, `Where`.
- Узагальнений метод `MaxBy<T>(IEnumerable<T>, Func<T,double>)`.
- Власний виняток `InvalidRatingException` (недопустимі оцінки <0 або >10).
- Використано LINQ: `Average`, `Min`, `Max`, `Where`, `Select`.
- Обробка винятків (`try-catch`).
- Демонстраційний запуск у `Program.cs`.

1. Відкрийте термінал у теці проекту (`lab5v5/lab5v5`).
2. Виконайте команди:
   ```bash
   dotnet build
   dotnet run
