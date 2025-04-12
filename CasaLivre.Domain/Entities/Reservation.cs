namespace CasaLivre.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PropertyId { get; set; }

    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }

    public User? User { get; set; }
    public Property? Property { get; set; }
}