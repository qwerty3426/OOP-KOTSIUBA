using LibraryManager.Domain;

namespace LibraryManager.Application;

public class LibraryService
{
    private readonly IRepository<Book> _bookRepository;

    public LibraryService(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void BorrowBook(string title)
    {
        // Використовуємо LINQ для пошуку книги за назвою серед усіх
        var book = _bookRepository.GetAll()
            .FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            
        if (book == null)
        {
            throw new ArgumentException("Book not found.");
        }

        book.Borrow(); 
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }
}