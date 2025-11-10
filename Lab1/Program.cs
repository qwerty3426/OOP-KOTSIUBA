using System;

class BankAccount
{
    private string owner;
    private string accountNumber;
    private double balance;

    public double Balance
    {
        get { return balance; }
    }

    public BankAccount(string owner, string accountNumber, double startBalance = 0)
    {
        this.owner = owner;
        this.accountNumber = accountNumber;
        this.balance = startBalance;
        Console.WriteLine($"Рахунок створено для {owner}, номер: {accountNumber}, початковий баланс: {balance}");
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Поповнено на {amount}. Новий баланс: {balance}");
        }
        else
        {
            Console.WriteLine("Сума повинна бути більшою за 0.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Знято {amount}. Новий баланс: {balance}");
        }
        else
        {
            Console.WriteLine("Недостатньо коштів або некоректна сума.");
        }
    }

    public void GetInfo()
    {
        Console.WriteLine($"Власник: {owner}, Номер рахунку: {accountNumber}, Баланс: {balance}");
    }

    ~BankAccount()
    {
        Console.WriteLine($"Рахунок {accountNumber} видалено.");
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount("Іван Петренко", "UA123456", 1000);
        acc.Deposit(500);
        acc.Withdraw(300);
        acc.GetInfo();
    }
}