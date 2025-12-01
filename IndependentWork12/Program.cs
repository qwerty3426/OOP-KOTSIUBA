using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace IndependentWork12
{
    class Program
    {
        static void Main()
        {
            // Розміри колекцій для тестування
            int[] sizes = { 1_000_000, 5_000_000, 10_000_000 };

            foreach (var size in sizes)
            {
                Console.WriteLine($"\n=== Тестування для колекції розміром {size} елементів ===");

                // Генерація колекції (значення 1..100)
                Random rnd = new Random(0); // фіксований seed для відтворюваності
                List<int> numbers = new List<int>(size);
                for (int i = 0; i < size; i++)
                    numbers.Add(rnd.Next(1, 100));

                // Вимір продуктивності
                MeasurePerformance(numbers);

                // Демонстрація побічних ефектів: некоректна vs. коректна сума
                UnsafePLINQ(numbers);
                SafePLINQ_WithLock(numbers);
                SafePLINQ_WithInterlocked(numbers);
            }
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number % 2 == 0) return number == 2;
            int limit = (int)Math.Sqrt(number);
            for (int i = 3; i <= limit; i += 2)
                if (number % i == 0) return false;
            return true;
        }

        static void MeasurePerformance(List<int> numbers)
        {
            var sw = Stopwatch.StartNew();
            var primesLinq = numbers.Where(n => IsPrime(n)).ToList();
            sw.Stop();
            Console.WriteLine($"LINQ час виконання: {sw.ElapsedMilliseconds} ms (знайдено {primesLinq.Count} простих)");

            sw.Restart();
            var primesPLinq = numbers.AsParallel().Where(n => IsPrime(n)).ToList();
            sw.Stop();
            Console.WriteLine($"PLINQ час виконання: {sw.ElapsedMilliseconds} ms (знайдено {primesPLinq.Count} простих)");
        }

        static void UnsafePLINQ(List<int> numbers)
        {
            int sum = 0;
            numbers.AsParallel().ForAll(n =>
            {
                // Некоректна операція: race condition
                sum += n;
            });
            Console.WriteLine($"Некоректна сума (без синхронізації): {sum}");
        }

        static void SafePLINQ_WithLock(List<int> numbers)
        {
            int sum = 0;
            object lockObj = new object();
            numbers.AsParallel().ForAll(n =>
            {
                lock (lockObj)
                {
                    sum += n;
                }
            });
            Console.WriteLine($"Коректна сума (з lock): {sum}");
        }

        static void SafePLINQ_WithInterlocked(List<int> numbers)
        {
            int sum = 0;
            numbers.AsParallel().ForAll(n =>
            {
                Interlocked.Add(ref sum, n);
            });
            Console.WriteLine($"Коректна сума (з Interlocked): {sum}");
        }
    }
}
