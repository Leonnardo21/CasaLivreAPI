using CasaLivre.Domain.Entities;
using CasaLivre.Domain.Interfaces;
using CasaLivre.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CasaLivre.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CasaLivreDbContext _context;

    public UserRepository(CasaLivreDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
        => await _context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(Guid id)
        => await _context.Users.FindAsync(id);

    public async Task<User?> GetByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user)
        => await _context.Users.AddAsync(user);

    public void Update(User user)
        => _context.Users.Update(user);

    public void Delete(User user)
        => _context.Users.Remove(user);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}