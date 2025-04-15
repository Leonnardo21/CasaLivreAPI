namespace CasaLivre.Domain.DTOs.Auth;

public class RegisterRequest
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}