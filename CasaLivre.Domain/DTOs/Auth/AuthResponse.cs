namespace CasaLivre.Domain.DTOs.Auth;

public class AuthResponse
{
    public string Token { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    
}