using System;

namespace Lab2Namespace
{
    // Варіант 5

    class MyCollection
    {
        private int[] items = new int[10];

        // Індексатор
        public int this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        // Метод для додавання елементів
        public void Add(int value)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == 0)
                {
                    items[i] = value;
                    break;
                }
            }
        }

        // Перевантажений метод
        public void Print()
        {
            Console.WriteLine("Елементи колекції:");
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Перевантаження оператора +
        public static MyCollection operator +(MyCollection c, int value)
        {
            c.Add(value);
            return c;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна 2, Варіант 5");

            MyCollection col = new MyCollection();

            // Додаємо елементи
            col.Add(10);
            col.Add(20);

            // Використовуємо індексатор
            col[2] = 30;

            // Перевантажені методи
            col.Print();
            col.Print("Колекція після додавання елементів:");

            // Використання перевантаженого оператора
            col += 40;
            col.Print("Після оператора +:");
        }
    }
}
