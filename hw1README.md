God Object (коротко і просто)

God Object — це ситуація, коли один клас робить майже все в програмі. У ньому зберігається багато даних і логіки, які насправді мали б бути розділені між різними класами.

Такий клас:

виходить дуже великий;

важкий для розуміння;

його складно змінювати, бо будь-яка правка може щось зламати;

часто порушує принцип SRP.

У результаті код стає заплутаним і незручним для підтримки.

Приклад класу з порушенням SRP
class UserManager
{
    public void RegisterUser(string name)
    {
        Console.WriteLine("User registered: " + name);
    }

    public void SaveUser(string name)
    {
        Console.WriteLine("User saved to database: " + name);
    }

    public void SendEmail(string name)
    {
        Console.WriteLine("Email sent to user: " + name);
    }
}

У чому проблема

Цей клас:

реєструє користувача;

зберігає його в базу;

надсилає повідомлення.

Тобто він виконує кілька різних задач одразу, через що порушується принцип Single Responsibility Principle.

Як це виправити (рефакторинг)

Краще розділити логіку на окремі класи, де кожен відповідає тільки за одну річ.

class UserService
{
    public void Register(string name)
    {
        Console.WriteLine("User registered: " + name);
    }
}

class UserRepository
{
    public void Save(string name)
    {
        Console.WriteLine("User saved to database: " + name);
    }
}

class EmailService
{
    public void Send(string name)
    {
        Console.WriteLine("Email sent to user: " + name);
    }
}

Чому так краще

код легше читати;

кожен клас має одне призначення;

простіше вносити зміни;

зменшується шанс появи God Object.