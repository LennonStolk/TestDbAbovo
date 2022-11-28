using Microsoft.EntityFrameworkCore;
using TestDbAbovo.Models;

namespace TestDbAbovo
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Klant> Klanten { get; set; } = null!;
        public DbSet<Medewerker> Medewerkers { get; set; } = null!;
        public DbSet<Afdeling> Afdelingen { get; set; } = null!;
        public DbSet<Project> Projecten { get; set; } = null!;
    }
}
