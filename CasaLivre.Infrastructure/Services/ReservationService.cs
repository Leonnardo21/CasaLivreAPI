using CasaLivre.Domain.DTOs.Reservation;
using CasaLivre.Domain.Entities;
using CasaLivre.Domain.Interfaces;

namespace CasaLivre.Infrastructure.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ReservationResponse?> CreateAsync(ReservationCreateRequest request)
    {
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            UserId = request.Userid,
            PropertyId = request.PropertyId,
            DateStart = request.DateStart,
            DateEnd = request.DateEnd
        };
        
        await _reservationRepository.CreateAsync(reservation);
        await _reservationRepository.SaveChangesAsync();
        
        return new ReservationResponse
        {
            Id = reservation.Id,
            UserId = reservation.UserId,
            PropertyId = reservation.PropertyId,
            DateStart = reservation.DateStart,
            DateEnd = reservation.DateEnd
        };
    }

    public async Task<ReservationResponse> GetByIdAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id);
        if (reservation == null) return null;

        return new ReservationResponse
        {
            Id = reservation.Id,
            UserId = reservation.UserId,
            PropertyId = reservation.PropertyId,
            DateStart = reservation.DateStart,
            DateEnd = reservation.DateEnd
        };
    }

    public async Task<IEnumerable<ReservationResponse>> GetAllAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync();
        
        return reservations.Select(r => new ReservationResponse
        {
            Id = r.Id,
            UserId = r.UserId,
            PropertyId = r.PropertyId,
            DateStart = r.DateStart,
            DateEnd = r.DateEnd
        });
    }

    public async Task<bool> Delete(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id);
        if (reservation == null) return false;

        _reservationRepository.Delete(reservation);
        return true;

    }
}