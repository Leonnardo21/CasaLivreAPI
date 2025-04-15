using CasaLivre.Domain.DTOs.Property;
using CasaLivre.Domain.Entities;
using CasaLivre.Domain.Interfaces;

namespace CasaLivre.Infrastructure.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }
    
    public async Task<Property> CreateAsync(PropertyCreateRequest request)
    {
        var property = new Property
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Address = request.Address,
            PricePerNight = request.PricePerNight,
            OwnerId = request.OwnerId,
        };

        await _propertyRepository.AddAsync(property);
        await _propertyRepository.SaveChangesAsync();
        return property;
    }

    public async Task<IEnumerable<Property>> GetAllAsync()
    {
        return await _propertyRepository.GetAllAsync();
    }

    public async Task<Property?> GetByIdAsync(Guid id)
    {
        return await _propertyRepository.GetByIdAsync(id);
    }

    public async Task<Property?> Update(Guid id, PropertyUpdateRequest request)
    {
        var property = await _propertyRepository.GetByIdAsync(id);
        if (property == null) return null;

        property.Title = request.Title;
        property.Description = request.Description;
        property.Address = request.Address;
        property.PricePerNight = request.PricePerNight;
        
        _propertyRepository.Update(property);
        await _propertyRepository.SaveChangesAsync();
        return property;

    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var property = await _propertyRepository.GetByIdAsync(id);
        if (property == null) return false;

        _propertyRepository.Delete(property);
        await _propertyRepository.SaveChangesAsync();
        return true;
    }
}