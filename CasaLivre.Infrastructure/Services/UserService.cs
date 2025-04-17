using CasaLivre.Domain.DTOs.User;
using CasaLivre.Domain.Interfaces;

namespace CasaLivre.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(user => new UserResponse
        {
            Id = user.Id,
            FullName = user.Name,
            Email = user.Email
        }).ToList();
    }

    public async Task<UserResponse?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user is null
            ? null
            : new UserResponse
            {
                Id = user.Id,
                FullName = user.Name,
                Email = user.Email
            };
    }
}