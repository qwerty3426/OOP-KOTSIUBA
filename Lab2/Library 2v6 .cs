using System.Collections.Generic;
using System.Linq;

namespace Lab2Library
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            if (book == null) throw new System.ArgumentNullException(nameof(book));
            books.Add(book);
        }

        // Метод повертає nullable Book, якщо книга не знайдена
        public Book? GetBookByTitle(string title)
        {
            return books.FirstOrDefault(b => b.Title == title);
        }

        public void PrintAllBooks()
        {
            if (books.Count == 0)
            {
                System.Console.WriteLine("Library is empty.");
                return;
            }

            foreach (var book in books)
            {
                System.Console.WriteLine(book);
            }
        }
    }
}
