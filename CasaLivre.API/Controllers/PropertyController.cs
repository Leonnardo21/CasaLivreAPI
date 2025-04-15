using CasaLivre.Domain.DTOs.Property;
using CasaLivre.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaLivre.API.Controllers;

[ApiController]
[Route("v1/properties")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var properties = await _propertyService.GetAllAsync();
        return Ok(properties);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var property = await _propertyService.GetByIdAsync(id);
        return property is null ? NotFound() : Ok(property);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PropertyCreateRequest request)
    {
        var property = await _propertyService.CreateAsync(request);
        return CreatedAtAction(nameof(Create), new { id = property.Id}, property);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PropertyUpdateRequest request)
    {
        var updated = await _propertyService.Update(id, request);
        return updated is null ? NotFound() : Ok(updated);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _propertyService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
    
}