using OmniReserve.Domain.Constants;
using OmniReserve.Domain.ValueObjects;

namespace OmniReserve.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public EmailAddress Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = string.Empty;
    public string Role { get; private set; } = Roles.Client;
    
    public ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();

    private User() { }

    public User(Guid id, string firstName, string lastName, EmailAddress email, string passwordHash, string role = Roles.Client)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }
}