```mermaid
classDiagram
    class Book {
        +Guid Id
        +String Title
        +Boolean IsAvailable
        +Borrow()
        +Return()
    }
    class IRepository~T~ {
        <<interface>>
        +GetAll()
        +GetById(Guid)
        +Add(T)
    }
    class LibraryService {
        +BorrowBook(String)
        +GetAllBooks()
    }
    LibraryService --> IRepository