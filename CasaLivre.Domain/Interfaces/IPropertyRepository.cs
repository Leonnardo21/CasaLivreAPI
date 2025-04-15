using CasaLivre.Domain.Entities;

namespace CasaLivre.Domain.Interfaces;

public interface IPropertyRepository 
{
    Task<IEnumerable<Property>> GetAllAsync();
    Task<Property?> GetByIdAsync(Guid id);
    Task<IEnumerable<Property>> GetByOwnerIdAsync(Guid ownerId);
    Task AddAsync(Property property);
    void Update(Property property);
    void Delete(Property property);
    Task SaveChangesAsync();
}