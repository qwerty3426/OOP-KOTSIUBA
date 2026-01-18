# Звіт з аналізу SOLID принципів (SRP, OCP) в Open-Source проєкті

## 1. Обраний проєкт

* **Назва:** ASP.NET Core
* **GitHub:** [https://github.com/dotnet/aspnetcore](https://github.com/dotnet/aspnetcore)
* **Стан коду:** актуальна гілка `main` (стан на 2026-01-18, код активно розвивається)

ASP.NET Core — великий open-source фреймворк на C#, що добре підходить для аналізу SOLID завдяки чіткій архітектурі, використанню інтерфейсів і шаблонів проєктування.

---

## 2. Аналіз SRP (Single Responsibility Principle)

### 2.1. Приклади дотримання SRP

#### Клас: `Logger<T>`

* **Відповідальність:** Запис логів для конкретного типу `T`.
* **Обґрунтування:**

  * Клас не займається зберіганням логів, форматуванням чи вибором місця запису.
  * Він лише делегує виклики провайдеру логування.

```csharp
public class Logger<T> : ILogger<T>
{
    private readonly ILogger _logger;

    public Logger(ILoggerFactory factory)
    {
        _logger = factory.CreateLogger(typeof(T));
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId,
        TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        _logger.Log(logLevel, eventId, state, exception, formatter);
    }
}
```

Єдина причина для зміни цього класу — зміна способу делегування логування.

---

#### Клас: `HttpContext`

* **Відповідальність:** Представлення контексту одного HTTP-запиту.
* **Обґрунтування:**

  * Містить лише дані та сервіси, пов’язані з конкретним запитом.
  * Бізнес-логіка обробки запиту винесена в middleware та контролери.

---

### 2.2. Приклад порушення SRP

#### Клас: `Startup` (типова реалізація в проєктах ASP.NET Core)

* **Множинні відповідальності:**

  * Конфігурація сервісів (DI).
  * Конфігурація HTTP pipeline.
  * Іноді — логіка вибору середовища (dev/prod).

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<AppDbContext>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
```

* **Проблеми:**

  * Клас змінюється з багатьох причин.
  * У великих проєктах перетворюється на «God Object».

---

## 3. Аналіз OCP (Open/Closed Principle)

### 3.1. Приклади дотримання OCP

#### Сценарій: Middleware Pipeline

* **Механізм розширення:** Інтерфейс `IMiddleware` та делегати.
* **Обґрунтування:**

  * Для додавання нової поведінки не потрібно змінювати існуючі middleware.
  * Достатньо створити новий клас і підключити його.

```csharp
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // нова логіка
        await _next(context);
    }
}
```

---

#### Сценарій: Логування (`ILogger`)

* **Механізм розширення:** Інтерфейси та провайдери (`ILoggerProvider`).
* **Обґрунтування:**

  * Можна додати новий спосіб логування (файл, БД, хмара) без зміни існуючого коду.

---

### 3.2. Приклад порушення OCP

#### Сценарій: Обробка типів конфігурацій через `switch`

```csharp
public void HandleConfig(string type)
{
    switch (type)
    {
        case "json": LoadJson(); break;
        case "xml": LoadXml(); break;
        case "yaml": LoadYaml(); break;
    }
}
```

* **Проблема:**

  * Додавання нового формату потребує зміни методу.
* **Наслідки:**

  * Порушення OCP.
  * Погіршення тестованості та розширюваності.

Краще рішення — Strategy або Factory з інтерфейсом.

---

## 4. Загальні висновки

* ASP.NET Core загалом добре дотримується SRP та OCP.
* Основні механізми розширення побудовані на інтерфейсах і DI.
* Порушення принципів здебільшого з’являються на рівні прикладного коду.
* Дотримання SRP та OCP значно підвищує підтримуваність і масштабованість системи.

**Висновок:** Архітектура ASP.NET Core є якісним прикладом практичного застосування SOLID у великому open-source проєкті.
