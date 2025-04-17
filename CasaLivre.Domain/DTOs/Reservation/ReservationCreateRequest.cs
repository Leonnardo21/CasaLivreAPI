namespace CasaLivre.Domain.DTOs.Reservation;

public class ReservationCreateRequest
{
    public Guid Userid { get; set; }
    public Guid PropertyId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}