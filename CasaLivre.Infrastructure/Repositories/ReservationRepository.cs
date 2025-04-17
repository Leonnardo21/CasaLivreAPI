using CasaLivre.Domain.Entities;
using CasaLivre.Domain.Interfaces;
using CasaLivre.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CasaLivre.Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly CasaLivreDbContext _context;

    public ReservationRepository(CasaLivreDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Reservation>> GetAllAsync()
        => await _context.Reservations.ToListAsync();

    public async Task<Reservation?> GetByIdAsync(Guid id)
        => await _context.Reservations.FindAsync(id);

    public async Task<IEnumerable<Reservation>> GetByUserIdAsync(Guid userId)
        => await _context.Reservations.Where(r => r.UserId == userId).ToListAsync();

    public async Task<IEnumerable<Reservation>> GetByPropertyIdAsync(Guid propertyId)
        => await _context.Reservations.Where(r => r.PropertyId == propertyId).ToListAsync();
    
    public async Task CreateAsync(Reservation reservation)
        => await _context.Reservations.AddAsync(reservation);

    public void Update(Reservation reservation)
        => _context.Reservations.Update(reservation);

    public void Delete(Reservation reservation)
        => _context.Reservations.Remove(reservation);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}