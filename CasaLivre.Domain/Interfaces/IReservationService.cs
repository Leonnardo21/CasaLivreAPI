using CasaLivre.Domain.DTOs.Reservation;
using CasaLivre.Domain.Entities;

namespace CasaLivre.Domain.Interfaces;

public interface IReservationService
{
    Task<ReservationResponse?> CreateAsync(ReservationCreateRequest request);
    Task<ReservationResponse?> GetByIdAsync(Guid id);
    Task<IEnumerable<ReservationResponse>> GetAllAsync();
    Task<bool> Delete(Guid id);
}