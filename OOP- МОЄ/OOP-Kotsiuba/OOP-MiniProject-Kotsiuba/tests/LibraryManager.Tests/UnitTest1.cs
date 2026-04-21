using LibraryManager.Domain;
using Xunit;

namespace LibraryManager.Tests;

public class BookTests
{
    [Fact]
    public void Borrow_WhenAvailable_SetsIsAvailableToFalse()
    {
        // Arrange (Підготовка)
        var book = new Book("Test Book");
        
        // Act (Дія)
        book.Borrow();
        
        // Assert (Перевірка)
        Assert.False(book.IsAvailable);
    }

    [Fact]
    public void Borrow_WhenNotAvailable_ThrowsInvalidOperationException()
    {
        var book = new Book("Test Book");
        book.Borrow(); // Перша видача проходить успішно
        
        // Друга видача має викинути помилку
        Assert.Throws<InvalidOperationException>(() => book.Borrow()); 
    }

    [Fact]
    public void Return_SetsIsAvailableToTrue()
    {
        var book = new Book("Test Book");
        book.Borrow();
        
        book.Return(); // Повертаємо книгу
        
        Assert.True(book.IsAvailable);
    }
}