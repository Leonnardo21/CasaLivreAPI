using CasaLivre.Domain.DTOs.Property;
using CasaLivre.Domain.Entities;

namespace CasaLivre.Domain.Interfaces;

public interface IPropertyService
{
    Task<Property> CreateAsync(PropertyCreateRequest request);
    Task<IEnumerable<Property>> GetAllAsync();
    Task<Property?> GetByIdAsync(Guid id);
    Task<Property?> Update(Guid id, PropertyUpdateRequest request);
    Task<bool> DeleteAsync(Guid id);
}