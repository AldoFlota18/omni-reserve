using OmniReserve.Domain.ValueObjects;

namespace OmniReserve.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public EmailAddress Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Enums.Role Role { get; private set; }
    
    public ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();

    public User(Guid id, string firstName, string lastName, string email, string passwordHash, Enums.Role role)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
        LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
        Email = new EmailAddress(email);
        PasswordHash = string.IsNullOrWhiteSpace(passwordHash) ? throw new ArgumentNullException(nameof(passwordHash)) : passwordHash;
        Role = role;
    }
}