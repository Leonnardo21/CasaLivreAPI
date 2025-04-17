using CasaLivre.Domain.Entities;
using CasaLivre.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaLivre.API.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, User updatedUser)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.PasswordHash = updatedUser.PasswordHash;

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null) return NotFound();

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}