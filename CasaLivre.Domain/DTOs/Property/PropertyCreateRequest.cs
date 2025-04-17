namespace CasaLivre.Domain.DTOs.Property;

public class PropertyCreateRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public decimal PricePerNight { get; set; }
    public Guid OwnerId { get; set; }
}