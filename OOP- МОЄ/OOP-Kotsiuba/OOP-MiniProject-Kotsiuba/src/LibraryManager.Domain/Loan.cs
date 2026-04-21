namespace LibraryManager.Domain;

public class Loan
{
    public Guid Id { get; }
    public Guid BookId { get; }
    public Guid UserId { get; }
    public DateTime Date { get; }

    public Loan(Guid bookId, Guid userId)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        UserId = userId;
        Date = DateTime.Now;
    }
}