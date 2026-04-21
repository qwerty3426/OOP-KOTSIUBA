using LibraryManager.Application;
using LibraryManager.Infrastructure;

// Створюємо репозиторій та сервіс
var repository = new InMemoryBookRepository();
var service = new LibraryService(repository);

while (true)
{
    Console.WriteLine("\n--- Library Menu ---");
    Console.WriteLine("1. View all books");
    Console.WriteLine("2. Borrow a book");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");
    
    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.WriteLine("\nBooks in library:");
                foreach (var book in service.GetAllBooks())
                {
                    var status = book.IsAvailable ? "Available" : "Borrowed";
                    Console.WriteLine($"- {book.Title} ({status})");
                }
                break;
            case "2":
                Console.Write("\nEnter book title to borrow: ");
                var title = Console.ReadLine();
                service.BorrowBook(title);
                Console.WriteLine("Successfully borrowed!");
                break;
            case "3":
                Console.WriteLine("Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError: {ex.Message}");
    }
}