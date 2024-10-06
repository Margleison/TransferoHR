using DentalRJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalRJ.Infra.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Defina suas DbSets aqui
        public DbSet<Company> Company { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
    }
}