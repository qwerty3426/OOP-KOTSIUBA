# Code Smells та рефакторинг: практичний аналіз

## Вступ

У даній роботі проведено аналіз програмного коду, написаного мовою C#, з метою виявлення проблемних місць (code smells) та їх подальшого усунення за допомогою рефакторингу. Рефакторинг дозволяє покращити внутрішню структуру коду без зміни його функціональності, що робить програму більш зрозумілою, гнучкою та зручною для підтримки.

---

## 1. Long Method (Довгий метод)

### Проблема

У коді був присутній метод, який виконував одразу декілька задач: валідацію даних, обчислення та виведення результату. Такий підхід ускладнює розуміння коду та його підтримку.

### До рефакторингу

```csharp
public void ProcessOrder(Order order)
{
    if (order == null) return;

    if (order.Items.Count == 0)
        Console.WriteLine("Empty order");

    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }

    Console.WriteLine("Total: " + total);
}
```

### Рішення

Застосовано техніку Extract Method — розбиття методу на менші частини.

### Після рефакторингу

```csharp
public void ProcessOrder(Order order)
{
    if (!IsValid(order)) return;

    decimal total = CalculateTotal(order);
    PrintTotal(total);
}

private bool IsValid(Order order)
{
    return order != null && order.Items.Count > 0;
}

private decimal CalculateTotal(Order order)
{
    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }
    return total;
}

private void PrintTotal(decimal total)
{
    Console.WriteLine("Total: " + total);
}
```

---

## 2. Duplicate Code (Дублювання коду)

### Проблема

У програмі використовувалась однакова логіка обчислення ціни в різних методах, що ускладнює підтримку коду.

### До рефакторингу

```csharp
public decimal GetRetailPrice(decimal basePrice)
{
    return basePrice * 1.2m;
}

public decimal GetWholesalePrice(decimal basePrice)
{
    return basePrice * 1.2m * 0.9m;
}
```

### Рішення

Використано Extract Method — винесення спільної логіки в окремий метод.

### Після рефакторингу

```csharp
private decimal ApplyMarkup(decimal price)
{
    return price * 1.2m;
}

public decimal GetRetailPrice(decimal basePrice)
{
    return ApplyMarkup(basePrice);
}

public decimal GetWholesalePrice(decimal basePrice)
{
    return ApplyMarkup(basePrice) * 0.9m;
}
```

---

## 3. Magic Numbers (Магічні числа)

### Проблема

У коді використовувались числові значення без пояснення їх призначення, що знижує читабельність.

### До рефакторингу

```csharp
if (user.Age > 18)
{
    discount = total * 0.15m;
}
```

### Рішення

Застосовано Extract Constant — заміна магічних чисел на іменовані константи.

### Після рефакторингу

```csharp
private const int AdultAge = 18;
private const decimal DiscountRate = 0.15m;

if (user.Age > AdultAge)
{
    discount = total * DiscountRate;
}
```

---

## Чому рефакторинг без тестів є ризикованим

Рефакторинг передбачає зміну структури коду без зміни його поведінки. Проте без наявності тестів неможливо гарантувати, що програма працює правильно після внесених змін. Навіть незначні зміни можуть призвести до появи помилок, які складно одразу помітити. Наприклад, при розбитті методу на декілька частин можна випадково змінити логіку обчислень або пропустити важливу перевірку. Тести дозволяють швидко перевірити, чи залишилась поведінка програми незмінною після рефакторингу.

---

## Висновок

У результаті виконання роботи було виявлено та усунуто кілька поширених проблем у коді, таких як довгі методи, дублювання коду та використання магічних чисел. Застосування технік рефакторингу дозволило покращити структуру програми, зробити код більш зрозумілим та зручним для подальшої підтримки. Рефакторинг є важливою практикою у розробці програмного забезпечення, особливо при роботі з великими проєктами.
ІІ