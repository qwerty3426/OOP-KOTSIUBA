using System;
using System.Net.Http;
using System.Threading;
using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;

class Program
{
    private static int _apiCallAttempts = 0;
    private static int _dbCallAttempts = 0;

    static void Main()
    {
        Console.WriteLine("--- Scenario 1: External API Call with Retry ---");
        var retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetry(3,
                attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Retry {retryCount} after {timeSpan.TotalSeconds}s due to: {exception.Message}");
                });

        try
        {
            string result = retryPolicy.Execute(() => CallExternalApi("https://api.example.com/data"));
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Final Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Operation failed after all retries: {ex.Message}");
        }

        Console.WriteLine("\n--- Scenario 2: Database Call with Circuit Breaker ---");
        var circuitBreakerPolicy = Policy
            .Handle<Exception>()
            .CircuitBreaker(2, TimeSpan.FromSeconds(5),
                onBreak: (ex, breakDelay) => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Circuit broken! Duration: {breakDelay.TotalSeconds}s"),
                onReset: () => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Circuit reset."),
                onHalfOpen: () => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Circuit half-open, testing next call."));

        for (int i = 0; i < 5; i++)
        {
            try
            {
                circuitBreakerPolicy.Execute(() => CallDatabase());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] DB call failed: {ex.Message}");
            }
            Thread.Sleep(1000);
        }

        Console.WriteLine("\n--- Scenario 3: Long Operation with Timeout ---");
        var timeoutPolicy = Policy.Timeout(2, TimeoutStrategy.Pessimistic, (context, timespan, task) =>
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Operation timed out after {timespan.TotalSeconds}s");
        });

        try
        {
            timeoutPolicy.Execute(() => LongOperation());
        }
        catch (TimeoutRejectedException)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Operation failed due to timeout.");
        }

        Console.WriteLine("\n--- End of All Scenarios ---");
    }

    static string CallExternalApi(string url)
    {
        _apiCallAttempts++;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Attempt {_apiCallAttempts}: Calling API {url}...");
        if (_apiCallAttempts <= 2) throw new HttpRequestException($"API call failed for {url}");
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] API call successful!");
        return "Data from API";
    }

    static void CallDatabase()
    {
        _dbCallAttempts++;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] DB Call Attempt {_dbCallAttempts}");
        if (_dbCallAttempts % 2 != 0) throw new Exception("Temporary DB error");
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] DB Call successful");
    }

    static void LongOperation()
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Starting long operation...");
        Thread.Sleep(5000); // Імітація тривалої операції
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Long operation completed");
    }
}

/*
ЗВІТ:
=========================================
1. Сценарій 1: Виклик зовнішнього API з Retry
- Проблема: API може тимчасово повертати помилки
- Політика: Retry з експоненційною затримкою (2, 4, 8 секунд)
- Очікувана поведінка: 2 помилки → автоматичні повтори → успішний виклик
- Логи демонструють кожну спробу та затримку

2. Сценарій 2: Доступ до БД з Circuit Breaker
- Проблема: БД може тимчасово недоступна
- Політика: Circuit Breaker (2 помилки → блокування на 5 секунд)
- Очікувана поведінка: при двох помилках наступні виклики блокуються, потім Circuit reset
- Логи демонструють стан Circuit (Open/Half-Open/Closed)

3. Сценарій 3: Довга операція з Timeout
- Проблема: Операція може зависнути
- Політика: Timeout (2 секунди)
- Очікувана поведінка: якщо операція >2с → TimeoutRejectedException → лог про таймаут

Висновки:
- Polly дозволяє реалізувати відмовостійкість легко і гнучко.
- Retry, Circuit Breaker, Timeout допомагають контролювати поведінку системи при тимчасових збоях.
- Логування забезпечує видимість роботи політик та допомагає відлагоджувати проблеми.
*/
