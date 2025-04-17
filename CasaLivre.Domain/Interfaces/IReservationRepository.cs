using CasaLivre.Domain.Entities;

namespace CasaLivre.Domain.Interfaces;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(Guid id);
    Task<IEnumerable<Reservation>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Reservation>> GetByPropertyIdAsync(Guid propertyId);
    Task CreateAsync(Reservation reservation);
    void Update(Reservation reservation);
    void Delete(Reservation reservation);
    Task SaveChangesAsync();
}