namespace LibraryManager.Domain;

public abstract class User
{
    public Guid Id { get; }
    public string Name { get; }

    protected User(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty");

        Id = Guid.NewGuid();
        Name = name;
    }
}