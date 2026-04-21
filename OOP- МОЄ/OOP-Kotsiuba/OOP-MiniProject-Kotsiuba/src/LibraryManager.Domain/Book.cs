namespace LibraryManager.Domain;

public class Book
{
    public Guid Id { get; }
    public string Title { get; }
    public bool IsAvailable { get; private set; }

    public Book(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty");

        Id = Guid.NewGuid();
        Title = title;
        IsAvailable = true;
    }

    public void Borrow()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("Book already borrowed");

        IsAvailable = false;
    }

    public void Return()
    {
        IsAvailable = true;
    }
}