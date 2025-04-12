namespace CasaLivre.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public bool isOwner { get; set; }

    public ICollection<Property> Properties { get; set; } = new List<Property>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}