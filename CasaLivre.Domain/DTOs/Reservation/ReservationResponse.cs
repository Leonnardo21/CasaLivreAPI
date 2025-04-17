namespace CasaLivre.Domain.DTOs.Reservation;

public class ReservationResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PropertyId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}