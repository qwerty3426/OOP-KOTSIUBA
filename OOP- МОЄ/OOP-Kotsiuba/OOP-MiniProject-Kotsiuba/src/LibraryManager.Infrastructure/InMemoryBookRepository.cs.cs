using LibraryManager.Domain;

namespace LibraryManager.Infrastructure;

public class InMemoryBookRepository : IRepository<Book>
{
    private readonly List<Book> _books = new();

    public InMemoryBookRepository()
    {
        // Додаємо книги для тестування консолі
        _books.Add(new Book("The Lord of the Rings"));
        _books.Add(new Book("1984"));
    }

    public void Add(Book entity) => _books.Add(entity);
    public IEnumerable<Book> GetAll() => _books;
    public Book GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);
    
    // Спеціальний метод для нашого консольного сценарію
    public Book GetByTitle(string title) 
        => _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
}