using System.Reflection;
using CasaLivre.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaLivre.Infrastructure.Persistence;

public class CasaLivreDbContext : DbContext
{
    public CasaLivreDbContext(DbContextOptions<CasaLivreDbContext> options): base(options){}

    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}