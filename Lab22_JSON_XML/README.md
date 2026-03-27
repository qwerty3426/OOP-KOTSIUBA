# JSON vs XML: практичне порівняння

## Вступ

У даній роботі розглянуто процес серіалізації та десеріалізації даних у форматах JSON та XML у мові програмування C#. Проведено порівняння цих форматів та визначено їх переваги і недоліки.

---

## Опис класу

Було створено клас Person з декількома властивостями:

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
}
```

---

## Серіалізація в JSON

```csharp
using System.Text.Json;

var person = new Person
{
    Id = 1,
    Name = "Artem",
    Age = 20,
    Email = "artem@gmail.com",
    City = "Kyiv"
};

string json = JsonSerializer.Serialize(person, new JsonSerializerOptions
{
    WriteIndented = true
});

File.WriteAllText("person.json", json);
```

### Результат JSON

```json
{
  "Id": 1,
  "Name": "Artem",
  "Age": 20,
  "Email": "artem@gmail.com",
  "City": "Kyiv"
}
```

---

## Серіалізація в XML

```csharp
using System.Xml.Serialization;

XmlSerializer serializer = new XmlSerializer(typeof(Person));

using (StreamWriter writer = new StreamWriter("person.xml"))
{
    serializer.Serialize(writer, person);
}
```

### Результат XML

```xml
<Person>
  <Id>1</Id>
  <Name>Artem</Name>
  <Age>20</Age>
  <Email>artem@gmail.com</Email>
  <City>Kyiv</City>
</Person>
```

---

## Порівняння JSON та XML

| Критерій      | JSON     | XML        |
| ------------- | -------- | ---------- |
| Розмір        | Менший   | Більший    |
| Читабельність | Вища     | Нижча      |
| Швидкість     | Швидше   | Повільніше |
| Популярність  | Веб, API | Enterprise |

---

## Де використовується JSON

* REST API
* Веб-додатки
* Мобільні додатки
* Конфігурації

---

## Де використовується XML

* SOAP сервіси
* Enterprise системи
* Конфігураційні файли
* Інтеграції зі старими системами

---

## Висновок

JSON є більш зручним та швидким форматом, тому широко використовується у сучасній розробці. XML залишається актуальним у великих корпоративних системах, де важлива строгість структури та валідація.
