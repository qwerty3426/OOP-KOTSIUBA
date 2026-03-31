using System;
using System.Collections.Generic;

/// <summary>
/// Базовий клас "Прилад"
/// </summary>
abstract class Device
{
    protected double power;

    // Конструктор базового класу
    public Device(double power)
    {
        this.power = power;
        Console.WriteLine($"{GetType().Name} created with {power} W");
    }

    // Віртуальний метод для підрахунку споживання
    public virtual double PowerUsage()
    {
        return power;
    }

    // Деструктор
    ~Device()
    {
        Console.WriteLine($"{GetType().Name} destroyed");
    }
}

/// <summary>
/// Ноутбук
/// </summary>
class Laptop : Device
{
    public Laptop(double power) : base(power) { }

    public override double PowerUsage()
    {
        return power;
    }

    ~Laptop()
    {
        Console.WriteLine("Laptop destructor called");
    }
}

/// <summary>
/// Холодильник
/// </summary>
class Fridge : Device
{
    public Fridge(double power) : base(power) { }

    public override double PowerUsage()
    {
        return power;
    }

    ~Fridge()
    {
        Console.WriteLine("Fridge destructor called");
    }
}

class Program
{
    static void Main()
    {
        List<Device> devices = new List<Device>
        {
            new Laptop(60),
            new Fridge(150)
        };

        double totalEnergy = 0;
        foreach (var d in devices)
        {
            double daily = d.PowerUsage() * 24 / 1000.0;
            Console.WriteLine($"{d.GetType().Name} uses {daily:F2} kWh per day");
            totalEnergy += daily;
        }

        Console.WriteLine($"Total energy usage: {totalEnergy:F2} kWh/day");
    }
}


