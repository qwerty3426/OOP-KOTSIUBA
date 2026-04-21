```mermaid
sequenceDiagram
    actor User
    participant Console
    participant LibraryService
    participant Book
    
    User->>Console: Enter book title
    Console->>LibraryService: BorrowBook(title)
    LibraryService->>Book: Borrow()
    Book-->>LibraryService: success
    LibraryService-->>Console: Display Success Message
    Console-->>User: "Successfully borrowed!"