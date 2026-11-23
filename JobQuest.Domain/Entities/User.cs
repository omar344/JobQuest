namespace JobQuest.Domain.Entities;

using JobQuest.Domain.ValueObjects;

public class User
{
    public int Id { get; private set; }

    public Email Email { get; private set; } = null!;

    public string PasswordHash { get; private set; } = null!;

    public string? Username { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // Required by EF Core
    protected User()
    {
    }

    private User(Email email, string passwordHash, string? username)
    {
        Email = email;
        PasswordHash = passwordHash;
        Username = username;
        CreatedAt = DateTime.UtcNow;
    }

    public static User Create(
    Email email,
    string passwordHash,
    string? username = null)
    {
        ArgumentNullException.ThrowIfNull(email);

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException(
                "Password hash is required.",
                nameof(passwordHash));

        username = string.IsNullOrWhiteSpace(username)
            ? null
            : username.Trim();

        return new User(email, passwordHash, username);
    }
}