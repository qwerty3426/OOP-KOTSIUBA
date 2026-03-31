using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6_v5
{
    // Власний делегат (базовий)
    delegate double Operation(double a, double b);

    class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string position, double salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }
    }

    class Program
    {
        // Подія для виводу повідомлення
        public static event Action<string> Notify;

        static void Main()
        {
            // Підписка на подію
            Notify += message => Console.WriteLine($"[EVENT] {message}");

            // Колекція працівників
            List<Employee> employees = new List<Employee>
            {
                new Employee("Ivan", "Developer", 12000),
                new Employee("Olena", "Manager", 9000),
                new Employee("Oleg", "Developer", 15000),
                new Employee("Sofia", "Designer", 8000),
                new Employee("Petro", "CEO", 20000)
            };

            Notify?.Invoke("=== Анонімний метод ===");
            // Анонімний метод
            Operation multiply = delegate (double a, double b) { return a * b; };
            Console.WriteLine($"5 * 3 = {multiply(5, 3)}");

            Notify?.Invoke("=== Лямбда-вираз ===");
            // Лямбда-вираз
            Operation add = (a, b) => a + b;
            Console.WriteLine($"5 + 3 = {add(5, 3)}");

            Notify?.Invoke("=== Func, Action, Predicate ===");
            // Func<T,bool> для відбору працівників із зарплатою > 10000
            Func<Employee, bool> highSalaryFunc = e => e.Salary > 10000;

            // Action<Employee> для виводу
            Action<Employee> printEmployee = e => 
                Console.WriteLine($"{e.Name} - {e.Position} - {e.Salary}");

            // Predicate<int> для перевірки парних чисел
            Predicate<int> isEven = n => n % 2 == 0;

            // Action<string> для загального виводу
            Action<string> print = s => Console.WriteLine(s);

            // Демонстрація Func + Action
            employees.Where(highSalaryFunc).ToList().ForEach(printEmployee);

            // Демонстрація Predicate
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            numbers.FindAll(isEven).ForEach(n => Console.WriteLine($"{n} - парне"));

            // LINQ: сортування за зарплатою
            var sortedEmployees = employees.OrderByDescending(e => e.Salary);
            Console.WriteLine("\nСортування за зарплатою (від більшої до меншої):");
            foreach (var emp in sortedEmployees)
                printEmployee(emp);

            // LINQ: середня зарплата
            double avgSalary = employees.Average(e => e.Salary);
            Console.WriteLine($"\nСередня зарплата: {avgSalary}");

            // LINQ: загальна сума зарплат
            double totalSalary = employees.Aggregate(0.0, (sum, e) => sum + e.Salary);
            Console.WriteLine($"Загальна сума зарплат: {totalSalary}");

            // Бонус: комбіновані делегати
            Action combinedAction = () => Notify?.Invoke("Перша дія делегату");
            combinedAction += () => Notify?.Invoke("Друга дія делегату");
            combinedAction.Invoke();
        }
    }
}
