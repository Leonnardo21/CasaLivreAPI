using CasaLivre.Domain.DTOs.Reservation;
using CasaLivre.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaLivre.API.Controllers;

[ApiController]
[Route("v1/reservations")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Create([FromBody] ReservationCreateRequest request)
    {
        var reservation = await _reservationService.CreateAsync(request);
        return reservation is null ? BadRequest("Erro ao criar reserva") : Ok(reservation);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        return reservation is null ? NotFound() : Ok(reservation);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reservation = await _reservationService.GetAllAsync();
        return Ok(reservation);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _reservationService.Delete(id);
        return success ? NoContent() : NotFound();
    }
}