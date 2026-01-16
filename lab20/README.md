# Лабораторна робота №20
**Тема:** SRP: декомпозиція OrderProcessor  
**Мета:** Застосувати принцип єдиної відповідальності (SRP) для декомпозиції складного класу OrderProcessor на менші, більш сфокусовані компоненти.

## Опис
Було створено клас `OrderProcessor`, який порушує SRP (робить валідацію, збереження та відправку email одночасно).  
Після рефакторингу клас розбитий на:

- `IOrderValidator` → `OrderValidator`
- `IOrderRepository` → `InMemoryOrderRepository`
- `IEmailService` → `ConsoleEmailService`
- `OrderService` → координує роботу компонентів через Dependency Injection

## Приклад коду

```csharp
// Демонстрація роботи в Main
![alt text](image.png)
var validator = new OrderValidator();
var repository = new InMemoryOrderRepository();
var emailService = new ConsoleEmailService();
var orderService = new OrderService(validator, repository, emailService);

var validOrder = new Order(1, "Ivan Ivanov", 100);
orderService.ProcessOrder(validOrder);

var invalidOrder = new Order(2, "Petro Petrov", 0);
orderService.ProcessOrder(invalidOrder);
