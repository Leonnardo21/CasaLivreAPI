using CasaLivre.Domain.DTOs.Auth;

namespace CasaLivre.Domain.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> RegisterAsync(RegisterRequest request);
    Task<AuthResponse?> LoginAsync(LoginRequest request);
}