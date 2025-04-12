namespace CasaLivre.Domain.Entities;

public class Property
{
    public Guid Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    public decimal PricePerNight { get; set; }

    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}