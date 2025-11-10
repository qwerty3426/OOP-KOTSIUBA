namespace Lab2Library
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title ?? throw new System.ArgumentNullException(nameof(title));
            Author = author ?? throw new System.ArgumentNullException(nameof(author));
        }

        public override string ToString()
        {
            return $"\"{Title}\" by {Author}";
        }
    }
}
