using CasaLivre.Domain.DTOs.User;

namespace CasaLivre.Domain.Interfaces;

public interface IUserService
{
    Task<List<UserResponse>> GetAllAsync();
    Task<UserResponse?> GetByIdAsync(Guid id);
}