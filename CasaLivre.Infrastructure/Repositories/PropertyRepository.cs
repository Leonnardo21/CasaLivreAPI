using CasaLivre.Domain.Entities;
using CasaLivre.Domain.Interfaces;
using CasaLivre.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CasaLivre.Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly CasaLivreDbContext _context;

    public PropertyRepository(CasaLivreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Property>> GetAllAsync() => await _context.Properties.ToListAsync();
    

    public async Task<Property?> GetByIdAsync(Guid id)  => await _context.Properties.FindAsync(id);
    

    public async Task<IEnumerable<Property>> GetByOwnerIdAsync(Guid ownerId)
        => await _context.Properties
            .Where(p => p.OwnerId == ownerId)
            .ToListAsync();


    public async Task AddAsync(Property property) => await _context.Properties.AddAsync(property);


    public void Update(Property property) => _context.Properties.Update(property);


    public void Delete(Property property) => _context.Properties.Remove(property);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}